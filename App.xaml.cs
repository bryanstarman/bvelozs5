namespace bvelozs5
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();
            PersonRepo = personRepository;
            MainPage = new NavigationPage(new Vistas.vPersona());
        }
    }
}