using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FSWatcher.ConsoleApp.Settings;
using FSWatcher.Library.Entity;

namespace FSWatcher.ConsoleApp.Mapping
{
    public class TrackedFolderProfile : Profile
    {
        public TrackedFolderProfile()
            => CreateMap<FoldersSettings, TrackedFolder>()
                .ForMember(x => x.Templates, opt
                    => opt.ConvertUsing(new RuleFormatter(), src => src.Rules));
    }

    public class RuleFormatter : IValueConverter<IEnumerable<Rule>, Dictionary<Regex, string>>
    {
        public Dictionary<Regex, string> Convert(IEnumerable<Rule> source, ResolutionContext context)
            => source.ToDictionary(rule => new Regex(rule.Pattern), rule => rule.DestinationFolder);
    }
}
