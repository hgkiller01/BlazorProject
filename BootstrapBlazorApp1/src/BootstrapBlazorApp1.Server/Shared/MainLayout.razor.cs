using BootstrapBlazor.Components;
using System.Collections.Generic;

namespace BootstrapBlazorApp1.Server.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private IEnumerable<MenuItem> Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            // TODO: 菜单获取可以通过数据库获取，此处为示例直接拼装的菜单集合
            Menus = GetIconSideMenuItems();
        }

        private IEnumerable<MenuItem> GetIconSideMenuItems()
        {
            var ret = new List<MenuItem>
            {
                //new MenuItem() { Text = "返回组件库", Icon = "fa fa-fw fa-home", Url = "https://blazor.sdgxgz.com/components" },
                new MenuItem() { Text = "首頁", Icon = "fa fa-fw fa-fa", Url = "" },
                new MenuItem() { Text = "天氣預報", Icon = "fa fa-fw fa-check-square-o", Url = "weatherPage" },
                new MenuItem(){Text="主商品" ,Url="DessertPage"}
                //new MenuItem() { Text = "FetchData", Icon = "fa fa-fw fa-database", Url = "fetchdata" },
                //new MenuItem() { Text = "系统设置", Icon = "fa fa-fw fa-gears", Url = "#" },
                //new MenuItem() { Text = "权限设置", Icon = "fa fa-fw fa-users", Url = "#" },
                //new MenuItem() { Text = "日志设置", Icon = "fa fa-fw fa-database", Url = "#" }
            };

            return ret;
        }
    }
}
