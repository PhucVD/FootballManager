﻿using System;
using NLog;

namespace FootballManager.Common
{
    public class LogHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        public static void Debug(string message, Exception exception)
        {
            logger.Debug(exception, message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }
    }
}
