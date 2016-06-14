# BTC.Shared


- https://www.nuget.org/packages/BTC.Shared.DataTables/ 
- https://www.nuget.org/packages/BTC.Shared.QueryObjects/ 
- https://www.nuget.org/packages/BTC.Shared.Extensions/

- https://www.nuget.org/packages/BTC.Shared.Automapper/

Create some configs like this:


    public class AccountReportMapperConfig : EntityModelBaseMapConfig<AccountReport, AccountReportDto>
    {
        protected override void MapToModel(IMappingExpression<AccountReport, AccountReportDto> map)
        {
        }

        protected override void MapToEntity(IMappingExpression<AccountReportDto, AccountReport> map)
        {
            map.ForAllMembers(n=>n.Ignore());
            map.ForMember(n => n.RealizedPnLToday, e => e.MapFrom(x => x.RealizedPnLToday));
            map.ForMember(n => n.UnrealizedPnLToday, e => e.MapFrom(x => x.UnrealizedPnLToday));
            map.ForMember(n => n.DailyPnL, e => e.MapFrom(x => x.DailyPnL));
            map.ForMember(n => n.TotalAmount, e => e.MapFrom(x => x.TotalAmount));
            map.ForMember(n => n.Lockout, e => e.MapFrom(x => x.Lockout));
            map.ForMember(n => n.LockoutId, e => e.MapFrom(x => x.Lockout.Guid));
            map.ForMember(n => n.AccountId, e => e.MapFrom(x => x.AccountId));
        }
    }
 
Register it on startup:

var autoMapperSerivce = kernel.Get\<AutoMapperSerivce\>();\
autoMapperSerivce.RegisterMapperConfigs\<AccountReportMapperConfig\>();
autoMapperSerivce.RegisterMapperConfigs\<TestMapperConfig2\>();
autoMapperSerivce.Initialize();
