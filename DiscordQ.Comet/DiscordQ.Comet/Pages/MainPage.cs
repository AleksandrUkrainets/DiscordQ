using Comet;
using Button = Comet.Button;
using View = Comet.View;
using Microsoft.Maui.Graphics;

namespace DiscordQ.Comet.Pages
{
    public class MainPage : View
    {
        [State]
        private readonly UserProfile userProfile = new();

        private const string HINT_LABEL_GRAY_COLOR = "#A59F9F";
        private const string GRID_SEPARATOR_COLOR = "#e1e1e1";
        private const string BACKGROUND_COLOR = "#fbfbfb";
        private const string WHITE_COLOR = "#ffffff";
        private const string BUTTON_COLOR = "#24b780";

        [Body]
        private View body() => new ScrollView()
        {
            new VStack(spacing: 10)
            {
                EntryContainer(userProfile.NickName, "Nazwa użytkownika", "Wpisz swoju Nazwu", true),
                                
                EntryContainer(userProfile.FirstName, "Imię", "Wpisz swoje Imię"),

                EntryContainer(userProfile.LastName, "Drugie Imię", "Wpisz swoje Drugie Imię"),

                GreenButton(() => userProfile.SaveCurrentUser())


            }.Padding(10)
        }
        .Background(Color.FromArgb(BACKGROUND_COLOR));

        private VStack EntryContainer(Binding<String> value, string title, string placeholder, bool isReadonly = false)
        {
            return new VStack(spacing: 5)
            {
                new Text(title)
                    .HorizontalLayoutAlignment(Microsoft.Maui.Primitives.LayoutAlignment.Start)
                    .FontSize(12)
                    .Color(Color.FromArgb(HINT_LABEL_GRAY_COLOR)),
                new VStack()
                {

                    new TextField(value, placeholder)
                        .IsReadOnly(isReadonly)
                        .Background(Color.FromArgb(WHITE_COLOR))
                }.Padding(5)
                .RoundedBorder(25, Color.FromArgb(GRID_SEPARATOR_COLOR),2)
                .Background(Color.FromArgb(WHITE_COLOR))

            };
        }

        private VStack GreenButton(Action action)
        {
            return new VStack()
            {
                new VStack()
                {
                    new Button("Zapisz", () => userProfile.SaveCurrentUser())
                        .Background(Color.FromArgb(WHITE_COLOR))
                        .Color(Color.FromArgb(BUTTON_COLOR))
                }.Padding(15)
                .RoundedBorder(100, Color.FromArgb(BUTTON_COLOR), 2)
                .Background(Color.FromArgb(WHITE_COLOR))
                .FillHorizontal()
        };
        }
    }
}