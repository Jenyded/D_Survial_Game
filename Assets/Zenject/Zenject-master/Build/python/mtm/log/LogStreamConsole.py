
import os
import re
import sys
from mtm.ioc.Inject import Inject
import mtm.util.Util as Util
from mtm.log.Logger import LogType
import shutil

from mtm.util.Assert import *

class LogMap:
    def __init__(self, regex, sub):
        self.regex = regex
        self.sub = sub

class LogStreamConsole:
    _log = Inject('Logger')
    _sys = Inject('SystemHelper')
    _varManager = Inject('VarManager')
    _config = Inject('Config')

    def __init__(self, verbose, veryVerbose):
        self._verbose = verbose
        self._veryVerbose = veryVerbose

        self.headingPatterns = self._getPatterns('HeadingPatterns')
        self.headingMaps = self._getPatternMaps('HeadingPatternMaps')

        self.goodPatterns = self._getPatterns('GoodPatterns')
        self.goodMaps = self._getPatternMaps('GoodPatternMaps')

        self.infoPatterns = self._getPatterns('InfoPatterns')
        self.infoMaps = self._getPatternMaps('InfoPatternMaps')

        self.errorPatterns = self._getPatterns('ErrorPatterns')
        self.errorMaps = self._getPatternMaps('ErrorPatternMaps')

        self.warningPatterns = self._getPatterns('WarningPatterns')
        self.warningMaps = self._getPatternMaps('WarningPatternMaps')
        self.warningPatternsIgnore = self._getPatterns('WarningPatternsIgnore')

        self.debugPatterns = self._getPatterns('DebugPatterns')
        self.debugMaps = self._getPatternMaps('DebugPatternMaps')

        self._fileStream = None
        if self._config.tryGetBool(False, 'Console', 'OutputToFilteredLog'):
            self._fileStream = self._getFileStream()

    def log(self, logType, message):

        logType, message = self.classifyMessage(logType, message)

        if logType is not None:
            if logType == LogType.HeadingFailed or logType == LogType.Error:
                self._output(logType, message, sys.stderr)
            else:
                self._output(logType, message, sys.stdout)

            if self._fileStream:
                self._output(logType, message, self._fileStream)

    def _getFileStream(self):

        primaryPath = self._varManager.expand('[LogFilteredPath]')

        if not primaryPath:
            raise Exception("Could not find path for log file")

        previousPath = None
        if self._varManager.hasKey('LogFilteredPreviousPath'):
            previousPath = self._varManager.expand('[LogFilteredPreviousPath]')

        # Keep one old build log
        if os.path.isfile(primaryPath) and previousPath:
            shutil.copy2(primaryPath, previousPath)

        return open(primaryPath, 'w', encoding='utf-8', errors='ignore')

    def _output(self, logType, message, stream):

        stream.write('\n')

        if self._log.hasHeading and logType != LogType.Heading and logType != LogType.HeadingSucceeded and logType != LogType.HeadingFailed:
            stream.write('  ')

        stream.write(message)
        stream.flush()

    def _getPatternMaps(self, settingName):
        maps = self._config.tryGetDictionary({}, 'Console', settingName)

        result = []
        for key, value in maps.items():
            regex = re.compile(key)
            logMap = LogMap(regex, value)
            result.append(logMap)

        return result

    def _getPatterns(self, settingName):
        patternStrings = self._config.tryGetList([], 'Console', settingName)

        result = []
        for pattern in patternStrings:
            result.append(re.compile('.*' + pattern + '.*'))

        return result

    def tryMatchPattern(self, message, maps, patterns):
        for logMap in maps:
            if logMap.regex.match(message):
                return logMap.regex.sub(logMap.sub, message)

        for pattern in patterns:
            match = pattern.match(message)

            if match:
                groups = match.groups()

                if len(groups) > 0:
                    return groups[0]

                return message

        return None

    def classifyMessage(self, logType, message):

        if logType == LogType.Info or logType == LogType.Heading or logType == LogType.HeadingFailed or logType == LogType.HeadingSucceeded or logType == LogType.Good or logType == LogType.Warn or logType == LogType.Error:
            return logType, message

        parsedMessage = self.tryMatchPattern(message, self.errorMaps, self.errorPatterns)
        if parsedMessage:
            return LogType.Error, parsedMessage

        if not any(p.match(message) for p in self.warningPatternsIgnore):
            parsedMessage = self.tryMatchPattern(message, self.warningMaps, self.warningPatterns)
            if parsedMessage:
                return LogType.Warn, parsedMessage

        parsedMessage = self.tryMatchPattern(message, self.headingMaps, self.headingPatterns)
        if parsedMessage:
            return LogType.Heading, parsedMessage

        parsedMessage = self.tryMatchPattern(message, self.goodMaps, self.goodPatterns)
        if parsedMessage:
            return LogType.Good, parsedMessage

        parsedMessage = self.tryMatchPattern(message, self.infoMaps, self.infoPatterns)
        if parsedMessage:
            return LogType.Info, parsedMessage

        if self._verbose:
            parsedMessage = self.tryMatchPattern(message, self.debugMaps, self.debugPatterns)
            if parsedMessage:
                return LogType.Debug, parsedMessage

        if self._veryVerbose:
            return LogType.Debug, message

        return None, message

