﻿#region Copyright
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2013
// by DotNetNuke Corporation
// All Rights Reserved
#endregion

using System.Globalization;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Tokens;

namespace DotNetNuke.Services.Subscriptions.Entities.Templates
{
    public class ActionsContent : IPropertyAccess
    {
        #region Constructors

        public ActionsContent(Actions actions)
        {
            Actions = actions;
        }

        #endregion

        #region Private members

        private Actions Actions { get; set; }

        #endregion

        #region Implementation of IPropertyAccess

        public string GetProperty(string propertyName, string format, CultureInfo formatProvider, UserInfo accessingUser, Scope accessLevel, ref bool propertyNotFound)
        {
            switch (propertyName.ToLowerInvariant())
            {
                case "unsubscribeurl":
                    return string.IsNullOrEmpty(Actions.UnsubscribeUrl)
                        ? string.Empty
                        : Actions.UnsubscribeUrl.ToString(formatProvider);
                default:
                    propertyNotFound = true;
                    return null;
            }
        }

        public CacheLevel Cacheability
        {
            get
            {
                return CacheLevel.notCacheable;
            }
        }

        #endregion
    }
}