using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorDemoServer.Data;

namespace MudBlazorDemoServer.Pages
{

    public partial class FootballTeams : ComponentBase
    {

        [Inject] protected FootballTeamsService footballTeamsService { get; set; }
        [Inject] protected ISnackbar Snackbar { get; set; }
        private MudTable<FootballTeam> table;

        FootballTeam model = new FootballTeam();
        public List<FootballTeam> footballTeams;
        private IEnumerable<FootballTeam> searchedData;
        double[] chartData;
        string[] teams;
        private string colorValue1;
        private string colorValue2;
        private int totalItems;
        private string searchString;

        protected async Task<TableData<FootballTeam>> ServerReload(TableState state)
        {
            var data = footballTeamsService.GetSearchedData(searchString, state.Page, state.PageSize);
            searchedData = data.Item1;
            totalItems = data.Item2;
            DrawChart();
            return new TableData<FootballTeam>() { TotalItems = totalItems, Items = searchedData };
        }

        private void OnValidSubmit(EditContext context)
        {
            model.Colors = string.Join(",", new string[] { colorValue1, colorValue2 });
            footballTeamsService.AddFootballTeam(model);
            Snackbar.Add("The team added successfully!", Severity.Success);
            CleanUp();
            DrawChart();
        }

        private void Delete(string name)
        {
            bool result;
            result = footballTeamsService.Delete(name);

            if (result)
            {
                Snackbar.Add("The team removed successfully!", Severity.Success);
                DrawChart();
            }
            else
            {
                Snackbar.Add("An error occured!", Severity.Error);
            }
        }

        private void CleanUp()
        {
            model = new FootballTeam();
            colorValue1 = "";
            colorValue2 = "";
        }

        public void DrawChart()
        {
            teams = searchedData.Select(s => s.Name).ToArray();
            chartData = searchedData.Select(x => Convert.ToDouble(x.SupporterCount)).ToArray();
            StateHasChanged();
        }

        private void OnSearch(string text)
        {
            searchString = text;
            table.ReloadServerData();
        }
    }
}
