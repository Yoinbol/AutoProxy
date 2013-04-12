﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AutoProxy.Configuration
{
    internal class LibraryElement : ConfigurationElement, ILibrary
    {
        [ConfigurationProperty("output", IsRequired = true)]
        public string Output
        {
            get
            {
                return (string)this["output"];
            }
            set
            {
                this["output"] = value;
            }
        }

        [ConfigurationProperty("compress", IsRequired = false, DefaultValue = true)]
        public bool Compress
        {
            get
            {
                return (bool)this["compress"];
            }
            set
            {
                this["compress"] = value;
            }
        }

        [ConfigurationProperty("namespace", IsRequired = false)]
        public string Namespace
        {
            get
            {
                return (string)this["namespace"];
            }
            set
            {
                this["namespace"] = value;
            }
        }

        [ConfigurationProperty("Required", IsRequired = false)]
        public RequiredConfigurationCollection RequiredCollection
        {
            get
            {
                return ((RequiredConfigurationCollection)(base["Required"]));
            }
            set
            {
                base["Required"] = value;
            }
        }


        public IEnumerable<IFile> RequiredFiles
        {
            get
            {
                return this.RequiredCollection.OfType<FileElement>();
            }
        }

        [ConfigurationProperty("Controllers", IsRequired = false)]
        public ControllersConfigurationCollection ControllersCollection
        {
            get
            {
                return ((ControllersConfigurationCollection)(base["Controllers"]));
            }
            set
            {
                base["Controllers"] = value;
            }
        }


        public IEnumerable<IController> Controllers
        {
            get
            {
                return this.ControllersCollection.OfType<ControllerElement>();
            }
        }
    }
}