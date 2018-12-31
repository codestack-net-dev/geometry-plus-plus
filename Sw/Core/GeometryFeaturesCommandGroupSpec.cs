﻿using CodeStack.Community.GeometryPlusPlus.Base;
using CodeStack.Community.GeometryPlusPlus.Properties;
using CodeStack.SwEx.AddIn.Base;
using CodeStack.SwEx.AddIn.Core;
using CodeStack.SwEx.AddIn.Enums;
using CodeStack.SwEx.AddIn.Icons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.AppLaunchKit.Base.Services;
using CodeStack.SwEx.Common.Reflection;
using CodeStack.SwEx.Common.Attributes;
using SolidWorks.Interop.sldworks;

namespace CodeStack.Community.GeometryPlusPlus.Core
{
    public class GeometryFeaturesCommandGroupSpec : CommandGroupSpec
    {
        public GeometryFeaturesCommandGroupSpec(ISldWorks app, IGeometryMacroFeature[] features, IAboutApplicationService abtService)
        {
            Title = Resources.CommandBarGeometryTitle;
            Tooltip = Resources.CommandBarGeometryTooltip;
            Icon = new MasterIcon(Resources.geometry_plus_plus);
            Id = 0;
            Commands = GetCommands(features, abtService, app);
        }

        private ICommandSpec[] GetCommands(IGeometryMacroFeature[] features, IAboutApplicationService abtService, ISldWorks app)
        {
            var cmds = new List<ICommandSpec>();

            for (int i = 0; i < features.Length; i++)
            {
                cmds.Add(new GeometryFeatureCommandSpec(app, features[i], i));
            }
            
            cmds.Add(new AboutCommandSpec(abtService, cmds.Count));

            return cmds.ToArray();
        }
    }
}
