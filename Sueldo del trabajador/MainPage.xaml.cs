namespace Sueldo_del_trabajador
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editsueldo;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetSueldos());
        }


        private async void Guardarbtn_Clicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(sueldoEntryField.Text, out decimal sueldoInicial))
            {
                var sueldo = new Sueldo
                {
                    SueldoInicial = sueldoInicial
                };

                sueldo.AumentoAplicado();

                await DisplayAlert("Resultado", $"Sueldo Original: {sueldo.SueldoInicial:C}\n" +
                                                $"Aumento Aplicado: {sueldo.AumentoAplicado:P}\n" +
                                                $"Nuevo Sueldo: {sueldo.NuevoSueldo:C}", "OK");

                if (_editsueldo == 0)
                {
                    await _dbService.Create(sueldo);
                }
                else
                {
                    await _dbService.Update(sueldo);
                }

                sueldoEntryField.Text = string.Empty;
                _editsueldo = 0;

                listview.ItemsSource = await _dbService.GetSueldos();
            }
            else
            {
                await DisplayAlert("Error", "Ingrese un sueldo válido.", "OK");
            }
        }
        }
    }


