﻿namespace Turbo.Plugins.Jack
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Decorators.TopTables;

    public class DifficultiesInfoPlugin : BasePlugin, IInGameTopPainter
    {
        public TopTable Table { get; set; }

        private readonly string[,] difficultiesData = new string[,]
        {
            {   "-",        "GR1",      "GR4",      "GR7",      "GR10",     "GR13",     "GR16",     "GR19",     "GR22",     "GR25",     "GR30",     "GR35",     "GR40",     "GR45",     "GR50",     "GR55",     "GR60",         },
            {   "100%",     "200%",     "320%",     "512%",     "819%",     "1 311%",   "2 097%",   "3 355%",   "5 369%",   "8 590%",   "18 985%",  "41 625%",  "91 260%",  "200 082%", "438 669%", "961 759%", "2 108 607%",   },
            {   "100%",     "130",      "189%",     "273%",     "396%",     "575%",     "833%",     "1 208%",   "1 752%",   "2 540%",   "3 604%",   "5 097%",   "7 208%",   "10 194%",  "14 416%",  "20 387%",  "28 832%",      },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "8",        "1 150%",   "1 600%",   "1 900%",   "2 425%",   "3 100%",   "4 000%",   "5 000%",   "6 400%",   "8 200%",       },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "8",        "1 150%",   "1 600%",   "1 850%",   "2 150%",   "2 500%",   "2 900%",   "3 350%",   "3 900%",   "4 500%",       },
            {   "0%",       "0%",       "0%",       "0%",       "15%",      "32%",      "52%",      "75%",      "101%",     "131%",     "164%",     "205%",     "256%",     "320%",     "400%",     "500%",     "625%",         },
            {   "25%",      "25%",      "25%",      "25%",      "44%",      "65%",      "90%",      "119%",     "151%",     "189%",     "236%",     "295%",     "369%",     "461%",     "577%",     "721%",     "901%",         },
            {   "15%",      "18%",      "21%",      "25%",      "31%",      "37%",      "44%",      "53%",      "64%",      "75%",      "90%",      "2nd 15%",  "2nd 25%",  "2nd 50%",  "2nd 90%",  "3rd 12%",  "3rd 25%",      },
            {   "1",        "2nd 5%",   "2nd 10%",  "2nd 15%",  "2nd 20%",  "2nd 25%",  "2nd 31%",  "2nd 38%",  "2nd 44%",  "2nd 51%",  "2nd 60%",  "2nd 70%",  "2nd 80%",  "2nd 90%",  "2",        "3rd 12%",  "3rd 25%",      },
            {   "3",        "3",        "3",        "3",        "6",        "6",        "6",        "6",        "6",        "6",        "8",        "8",        "8",        "10",       "12",       "14",       "16",           },
            {   "10%",      "10%",      "10%",      "10%",      "10%",      "50%",      "60%",      "75%",      "90%",      "100%",     "2nd 5%",   "2nd 15%",  "2nd 25%",  "2nd 50%",  "2nd 65%",  "2nd 80%",  "2",            },
            {   "-",        "-",        "-",        "-",        "50%",      "75%",      "90%",      "100%",     "2nd 10%",  "2nd 20%",  "2nd 30%",  "2nd 40%",  "2nd 50%",  "2nd 60%",  "2nd 70%",  "2nd 80%",  "2nd 90%",      },
            {   "-",        "-",        "-",        "-",        "1",        "2nd 10%",  "2nd 25%",  "2nd 50%",  "2nd 75%",  "2nd 90%",  "200%",     "3rd 10%",  "3rd 25%",  "3rd 50%",  "3rd 75%",  "3rd 90%",  "3",            },
        };

        public DifficultiesInfoPlugin()
        {
            Enabled = true;
            Order = int.MaxValue;
        }

        private void InitTable()
        {
            Table = new TopTable(Hud)
            {
                RatioPositionX = 0.5f,
                RatioPositionY = 0.2f,
                HorizontalCenter = true,
                VerticalCenter = false,
                PositionFromRight = false,
                PositionFromBottom = false,
                ShowHeaderLeft = true,
                ShowHeaderTop = true,
                ShowHeaderRight = false,
                ShowHeaderBottom = false,
                DefaultCellDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHighlightDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 242, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHeaderDecorator = new TopTableCellDecorator(Hud)
                {
                    //BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    //BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                }
            };

            Table.DefineColumns(
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioHeight = 22 / 1080f, // define only once on first column, value on others will be ignored
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                },
                new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
                {
                    RatioWidth = 0.075f,
                    HighlightFunc = (pos, curPos) => HighlightColumn(pos),
                    TextAlign = HorizontalAlign.Center,
                }
            );

            for (var i = 0; i < 13; i++)
            {
                Table.AddLine(
                    new TopTableHeader(Hud, (pos, curPos) => GetLineHeaderText(pos))
                    {
                        RatioWidth = 62 / 1080f, // define only once on first line, value on other will be ignored
                        RatioHeight = 22 / 1080f,
                        HighlightFunc = (pos, curPos) => false,
                        TextAlign = HorizontalAlign.Right,
                        HighlightDecorator = new TopTableCellDecorator(Hud)
                        {
                            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                            BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                            TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
                        },
                        CellHighlightDecorator = new TopTableCellDecorator(Hud)
                        {
                            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                            BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                            TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
                        },
                    },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center },
                    new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => GetCellText(line, column)) { TextAlign = HorizontalAlign.Center }
                );
            }
        }

        private string GetCellText(int line, int column)
        {
            return difficultiesData[line, column];
        }

        private string GetColumnHeaderText(int pos)
        {
            switch (pos)
            {
                case 0:
                    return "Normal";

                case 1:
                    return "Hard";

                case 2:
                    return "Expert";

                case 3:
                    return "Master";

                default:
                    return string.Format("T{0}", pos - 3);
            }
        }

        private string GetLineHeaderText(int pos)
        {
            switch (pos)
            {
                case 0:
                    return "Greater Rift equivalent";

                case 1:
                    return "Monster health";

                case 2:
                    return "Monster damage";

                case 3:
                    return "+ XP";

                case 4:
                    return "+ Gold Find";

                case 5:
                    return "Legendary drop";

                case 6:
                    return "Legendary drop (rift)";

                case 7:
                    return "Death's Breath";

                case 8:
                    return "Greater Rift key";

                case 9:
                    return "Horadric Cache materials";

                case 10:
                    return "Horadric Cache legendaries";

                case 11:
                    return "Keywarden Machine drop";

                case 12:
                    return "Uber Organ drop";

                default:
                    return "";
            }
        }

        private bool HighlightColumn(int pos)
        {
            return (int)Hud.Game.GameDifficulty == pos;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (!Hud.Game.IsInTown) return;
            if (clipState != ClipState.AfterClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            if (!Hud.Window.CursorInsideRect(uiRect.Rectangle.X, uiRect.Rectangle.Y, uiRect.Rectangle.Width, uiRect.Rectangle.Height)) return;
            // if (!Hud.Window.CursorInsideRect(Hud.Window.Size.Width * 0.9f, Hud.Window.Size.Height * 0.02f, Hud.Window.Size.Width * 0.1f, Hud.Window.Size.Height * 0.02f)) return;

            if (Table == null)
                InitTable();
            else
                Table.Paint();
        }
    }
}