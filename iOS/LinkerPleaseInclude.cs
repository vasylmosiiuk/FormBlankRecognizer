using System;
using System.Collections.Generic;
using System.Text;
using FormVision.DO.Entities;
using FormVision.Resources.Localization;
using FormVision.Transformations;
using FormVision.Transformations.Mappers;

namespace FormVision.iOS
{
    sealed class LinkerPleaseInclude
    {
        public Strings LocalizationStrings { get; set; }
        public IEntity Entity { get; set; }
        public ModuleInitialization InitializationForTransformations { get; set; }
        public Services.Implementation.ModuleInitialization InitializationForServices { get; set; }
    }
}
