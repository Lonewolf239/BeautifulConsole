namespace BeautifulConsole.Models;

public partial class Color
{
    /// <summary>Gets a color with no value set.</summary>
    public static Color NoColor => new();

    /// <summary>Gets the pure white color (255, 255, 255).</summary>
    public static Color White => new(255, 255, 255);
    /// <summary>Gets the pure black color (0, 0, 0).</summary>
    public static Color Black => new(0, 0, 0);
    /// <summary>Gets the pure red color (255, 0, 0).</summary>
    public static Color Red => new(255, 0, 0);
    /// <summary>Gets the pure green color (0, 255, 0).</summary>
    public static Color Green => new(0, 255, 0);
    /// <summary>Gets the pure blue color (0, 0, 255).</summary>
    public static Color Blue => new(0, 0, 255);
    /// <summary>Gets the yellow color (255, 255, 0).</summary>
    public static Color Yellow => new(255, 255, 0);
    /// <summary>Gets the cyan color (0, 255, 255).</summary>
    public static Color Cyan => new(0, 255, 255);
    /// <summary>Gets the magenta color (255, 0, 255).</summary>
    public static Color Magenta => new(255, 0, 255);

    /// <summary>Gets the medium gray color (128, 128, 128).</summary>
    public static Color Gray => new(128, 128, 128);
    /// <summary>Gets the dark gray color (64, 64, 64).</summary>
    public static Color DarkGray => new(64, 64, 64);
    /// <summary>Gets the light gray color (192, 192, 192).</summary>
    public static Color LightGray => new(192, 192, 192);
    /// <summary>Gets a very dark gray almost black color (32, 32, 32).</summary>
    public static Color AlmostBlack => new(32, 32, 32);
    /// <summary>Gets the silver color (192, 192, 192).</summary>
    public static Color Silver => new(192, 192, 192);
    /// <summary>Gets the dim gray color (105, 105, 105).</summary>
    public static Color DimGray => new(105, 105, 105);

    /// <summary>Gets the dark red color (139, 0, 0).</summary>
    public static Color DarkRed => new(139, 0, 0);
    /// <summary>Gets the Indian red color (205, 92, 92).</summary>
    public static Color IndianRed => new(205, 92, 92);
    /// <summary>Gets the light coral color (240, 128, 128).</summary>
    public static Color LightCoral => new(240, 128, 128);
    /// <summary>Gets the salmon color (250, 128, 114).</summary>
    public static Color Salmon => new(250, 128, 114);
    /// <summary>Gets the dark salmon color (233, 150, 122).</summary>
    public static Color DarkSalmon => new(233, 150, 122);
    /// <summary>Gets the light salmon color (255, 160, 122).</summary>
    public static Color LightSalmon => new(255, 160, 122);
    /// <summary>Gets the crimson color (220, 20, 60).</summary>
    public static Color Crimson => new(220, 20, 60);
    /// <summary>Gets the fire brick color (178, 34, 34).</summary>
    public static Color FireBrick => new(178, 34, 34);
    /// <summary>Gets the maroon color (128, 0, 0).</summary>
    public static Color Maroon => new(128, 0, 0);
    /// <summary>Gets the brown color (165, 42, 42).</summary>
    public static Color Brown => new(165, 42, 42);
    /// <summary>Gets the saddle brown color (139, 69, 19).</summary>
    public static Color SaddleBrown => new(139, 69, 19);
    /// <summary>Gets the sienna color (160, 82, 45).</summary>
    public static Color Sienna => new(160, 82, 45);
    /// <summary>Gets the chocolate color (210, 105, 30).</summary>
    public static Color Chocolate => new(210, 105, 30);
    /// <summary>Gets the Peru color (205, 133, 63).</summary>
    public static Color Peru => new(205, 133, 63);
    /// <summary>Gets the rosy brown color (188, 143, 143).</summary>
    public static Color RosyBrown => new(188, 143, 143);

    /// <summary>Gets the orange color (255, 165, 0).</summary>
    public static Color Orange => new(255, 165, 0);
    /// <summary>Gets the dark orange color (255, 140, 0).</summary>
    public static Color DarkOrange => new(255, 140, 0);
    /// <summary>Gets the orange red color (255, 69, 0).</summary>
    public static Color OrangeRed => new(255, 69, 0);
    /// <summary>Gets the coral color (255, 127, 80).</summary>
    public static Color Coral => new(255, 127, 80);
    /// <summary>Gets the tomato color (255, 99, 71).</summary>
    public static Color Tomato => new(255, 99, 71);
    /// <summary>Gets the gold color (255, 215, 0).</summary>
    public static Color Gold => new(255, 215, 0);

    /// <summary>Gets the light yellow color (255, 255, 224).</summary>
    public static Color LightYellow => new(255, 255, 224);
    /// <summary>Gets the lemon chiffon color (255, 250, 205).</summary>
    public static Color LemonChiffon => new(255, 250, 205);
    /// <summary>Gets the light goldenrod yellow color (250, 250, 210).</summary>
    public static Color LightGoldenrodYellow => new(250, 250, 210);
    /// <summary>Gets the papaya whip color (255, 239, 213).</summary>
    public static Color PapayaWhip => new(255, 239, 213);
    /// <summary>Gets the moccasin color (255, 228, 181).</summary>
    public static Color Moccasin => new(255, 228, 181);
    /// <summary>Gets the peach puff color (255, 218, 185).</summary>
    public static Color PeachPuff => new(255, 218, 185);
    /// <summary>Gets the pale goldenrod color (238, 232, 170).</summary>
    public static Color PaleGoldenrod => new(238, 232, 170);
    /// <summary>Gets the khaki color (240, 230, 140).</summary>
    public static Color Khaki => new(240, 230, 140);
    /// <summary>Gets the dark khaki color (189, 183, 107).</summary>
    public static Color DarkKhaki => new(189, 183, 107);

    /// <summary>Gets the lime color (0, 255, 0).</summary>
    public static Color Lime => new(0, 255, 0);
    /// <summary>Gets the lime green color (50, 205, 50).</summary>
    public static Color LimeGreen => new(50, 205, 50);
    /// <summary>Gets the lawn green color (124, 252, 0).</summary>
    public static Color LawnGreen => new(124, 252, 0);
    /// <summary>Gets the chartreuse color (127, 255, 0).</summary>
    public static Color Chartreuse => new(127, 255, 0);
    /// <summary>Gets the green yellow color (173, 255, 47).</summary>
    public static Color GreenYellow => new(173, 255, 47);
    /// <summary>Gets the spring green color (0, 255, 127).</summary>
    public static Color SpringGreen => new(0, 255, 127);
    /// <summary>Gets the medium spring green color (0, 250, 154).</summary>
    public static Color MediumSpringGreen => new(0, 250, 154);
    /// <summary>Gets the light green color (144, 238, 144).</summary>
    public static Color LightGreen => new(144, 238, 144);
    /// <summary>Gets the pale green color (152, 251, 152).</summary>
    public static Color PaleGreen => new(152, 251, 152);
    /// <summary>Gets the dark green color (0, 100, 0).</summary>
    public static Color DarkGreen => new(0, 100, 0);
    /// <summary>Gets the forest green color (34, 139, 34).</summary>
    public static Color ForestGreen => new(34, 139, 34);
    /// <summary>Gets the sea green color (46, 139, 87).</summary>
    public static Color SeaGreen => new(46, 139, 87);
    /// <summary>Gets the dark sea green color (143, 188, 143).</summary>
    public static Color DarkSeaGreen => new(143, 188, 143);
    /// <summary>Gets the medium sea green color (60, 179, 113).</summary>
    public static Color MediumSeaGreen => new(60, 179, 113);
    /// <summary>Gets the olive color (128, 128, 0).</summary>
    public static Color Olive => new(128, 128, 0);
    /// <summary>Gets the olive drab color (107, 142, 35).</summary>
    public static Color OliveDrab => new(107, 142, 35);
    /// <summary>Gets the yellow green color (154, 205, 50).</summary>
    public static Color YellowGreen => new(154, 205, 50);

    /// <summary>Gets the dark cyan color (0, 139, 139).</summary>
    public static Color DarkCyan => new(0, 139, 139);
    /// <summary>Gets the light cyan color (224, 255, 255).</summary>
    public static Color LightCyan => new(224, 255, 255);
    /// <summary>Gets the pale turquoise color (175, 238, 238).</summary>
    public static Color PaleTurquoise => new(175, 238, 238);
    /// <summary>Gets the aquamarine color (127, 255, 212).</summary>
    public static Color Aquamarine => new(127, 255, 212);
    /// <summary>Gets the medium aquamarine color (102, 205, 170).</summary>
    public static Color MediumAquamarine => new(102, 205, 170);
    /// <summary>Gets the turquoise color (64, 224, 208).</summary>
    public static Color Turquoise => new(64, 224, 208);
    /// <summary>Gets the medium turquoise color (72, 209, 204).</summary>
    public static Color MediumTurquoise => new(72, 209, 204);
    /// <summary>Gets the dark turquoise color (0, 206, 209).</summary>
    public static Color DarkTurquoise => new(0, 206, 209);
    /// <summary>Gets the cadet blue color (95, 158, 160).</summary>
    public static Color CadetBlue => new(95, 158, 160);
    /// <summary>Gets the light sea green color (32, 178, 170).</summary>
    public static Color LightSeaGreen => new(32, 178, 170);

    /// <summary>Gets the light blue color (173, 216, 230).</summary>
    public static Color LightBlue => new(173, 216, 230);
    /// <summary>Gets the powder blue color (176, 224, 230).</summary>
    public static Color PowderBlue => new(176, 224, 230);
    /// <summary>Gets the sky blue color (135, 206, 235).</summary>
    public static Color SkyBlue => new(135, 206, 235);
    /// <summary>Gets the light sky blue color (135, 206, 250).</summary>
    public static Color LightSkyBlue => new(135, 206, 250);
    /// <summary>Gets the deep sky blue color (0, 191, 255).</summary>
    public static Color DeepSkyBlue => new(0, 191, 255);
    /// <summary>Gets the dodger blue color (30, 144, 255).</summary>
    public static Color DodgerBlue => new(30, 144, 255);
    /// <summary>Gets the cornflower blue color (100, 149, 237).</summary>
    public static Color CornflowerBlue => new(100, 149, 237);
    /// <summary>Gets the steel blue color (70, 130, 180).</summary>
    public static Color SteelBlue => new(70, 130, 180);
    /// <summary>Gets the royal blue color (65, 105, 225).</summary>
    public static Color RoyalBlue => new(65, 105, 225);
    /// <summary>Gets the medium blue color (0, 0, 205).</summary>
    public static Color MediumBlue => new(0, 0, 205);
    /// <summary>Gets the dark blue color (0, 0, 139).</summary>
    public static Color DarkBlue => new(0, 0, 139);
    /// <summary>Gets the navy color (0, 0, 128).</summary>
    public static Color Navy => new(0, 0, 128);
    /// <summary>Gets the midnight blue color (25, 25, 112).</summary>
    public static Color MidnightBlue => new(25, 25, 112);
    /// <summary>Gets the Alice blue color (240, 248, 255).</summary>
    public static Color AliceBlue => new(240, 248, 255);
    /// <summary>Gets the azure color (240, 255, 255).</summary>
    public static Color Azure => new(240, 255, 255);

    /// <summary>Gets the purple color (128, 0, 128).</summary>
    public static Color Purple => new(128, 0, 128);
    /// <summary>Gets the dark magenta color (139, 0, 139).</summary>
    public static Color DarkMagenta => new(139, 0, 139);
    /// <summary>Gets the dark violet color (148, 0, 211).</summary>
    public static Color DarkViolet => new(148, 0, 211);
    /// <summary>Gets the dark orchid color (153, 50, 204).</summary>
    public static Color DarkOrchid => new(153, 50, 204);
    /// <summary>Gets the blue violet color (138, 43, 226).</summary>
    public static Color BlueViolet => new(138, 43, 226);
    /// <summary>Gets the indigo color (75, 0, 130).</summary>
    public static Color Indigo => new(75, 0, 130);
    /// <summary>Gets the slate blue color (106, 90, 205).</summary>
    public static Color SlateBlue => new(106, 90, 205);
    /// <summary>Gets the medium slate blue color (123, 104, 238).</summary>
    public static Color MediumSlateBlue => new(123, 104, 238);
    /// <summary>Gets the medium purple color (147, 112, 219).</summary>
    public static Color MediumPurple => new(147, 112, 219);
    /// <summary>Gets the lavender color (230, 230, 250).</summary>
    public static Color Lavender => new(230, 230, 250);
    /// <summary>Gets the thistle color (216, 191, 216).</summary>
    public static Color Thistle => new(216, 191, 216);
    /// <summary>Gets the plum color (221, 160, 221).</summary>
    public static Color Plum => new(221, 160, 221);
    /// <summary>Gets the violet color (238, 130, 238).</summary>
    public static Color Violet => new(238, 130, 238);
    /// <summary>Gets the orchid color (218, 112, 214).</summary>
    public static Color Orchid => new(218, 112, 214);
    /// <summary>Gets the fuchsia color (255, 0, 255).</summary>
    public static Color Fuchsia => new(255, 0, 255);
    /// <summary>Gets the medium orchid color (186, 85, 211).</summary>
    public static Color MediumOrchid => new(186, 85, 211);

    /// <summary>Gets the pink color (255, 192, 203).</summary>
    public static Color Pink => new(255, 192, 203);
    /// <summary>Gets the light pink color (255, 182, 193).</summary>
    public static Color LightPink => new(255, 182, 193);
    /// <summary>Gets the hot pink color (255, 105, 180).</summary>
    public static Color HotPink => new(255, 105, 180);
    /// <summary>Gets the deep pink color (255, 20, 147).</summary>
    public static Color DeepPink => new(255, 20, 147);
    /// <summary>Gets the pale violet red color (219, 112, 147).</summary>
    public static Color PaleVioletRed => new(219, 112, 147);
    /// <summary>Gets the medium violet red color (199, 21, 133).</summary>
    public static Color MediumVioletRed => new(199, 21, 133);

    /// <summary>Gets the tan color (210, 180, 140).</summary>
    public static Color Tan => new(210, 180, 140);
    /// <summary>Gets the burly wood color (222, 184, 135).</summary>
    public static Color BurlyWood => new(222, 184, 135);
    /// <summary>Gets the sandy brown color (244, 164, 96).</summary>
    public static Color SandyBrown => new(244, 164, 96);
    /// <summary>Gets the goldenrod color (218, 165, 32).</summary>
    public static Color Goldenrod => new(218, 165, 32);
    /// <summary>Gets the dark goldenrod color (184, 134, 11).</summary>
    public static Color DarkGoldenrod => new(184, 134, 11);

    /// <summary>Gets the pastel red color (255, 102, 102).</summary>
    public static Color PastelRed => new(255, 102, 102);
    /// <summary>Gets the pastel green color (119, 221, 119).</summary>
    public static Color PastelGreen => new(119, 221, 119);
    /// <summary>Gets the pastel blue color (102, 153, 255).</summary>
    public static Color PastelBlue => new(102, 153, 255);
    /// <summary>Gets the pastel yellow color (255, 255, 153).</summary>
    public static Color PastelYellow => new(255, 255, 153);
    /// <summary>Gets the pastel purple color (204, 153, 255).</summary>
    public static Color PastelPurple => new(204, 153, 255);
    /// <summary>Gets the pastel pink color (255, 182, 193).</summary>
    public static Color PastelPink => new(255, 182, 193);
    /// <summary>Gets the pastel orange color (255, 179, 102).</summary>
    public static Color PastelOrange => new(255, 179, 102);
    /// <summary>Gets the pastel cyan color (153, 255, 255).</summary>
    public static Color PastelCyan => new(153, 255, 255);

    /// <summary>Gets the neon red color (255, 51, 51).</summary>
    public static Color NeonRed => new(255, 51, 51);
    /// <summary>Gets the neon green color (57, 255, 20).</summary>
    public static Color NeonGreen => new(57, 255, 20);
    /// <summary>Gets the neon blue color (77, 77, 255).</summary>
    public static Color NeonBlue => new(77, 77, 255);
    /// <summary>Gets the neon yellow color (255, 255, 51).</summary>
    public static Color NeonYellow => new(255, 255, 51);
    /// <summary>Gets the neon pink color (255, 110, 199).</summary>
    public static Color NeonPink => new(255, 110, 199);
    /// <summary>Gets the neon orange color (255, 95, 31).</summary>
    public static Color NeonOrange => new(255, 95, 31);
    /// <summary>Gets the neon purple color (155, 48, 255).</summary>
    public static Color NeonPurple => new(155, 48, 255);

    /// <summary>Gets the earth color (101, 67, 33).</summary>
    public static Color Earth => new(101, 67, 33);
    /// <summary>Gets the clay color (146, 86, 51).</summary>
    public static Color Clay => new(146, 86, 51);
    /// <summary>Gets the sand color (194, 178, 128).</summary>
    public static Color Sand => new(194, 178, 128);
    /// <summary>Gets the stone color (112, 104, 85).</summary>
    public static Color Stone => new(112, 104, 85);
    /// <summary>Gets the moss color (138, 154, 91).</summary>
    public static Color Moss => new(138, 154, 91);
    /// <summary>Gets the forest color (34, 79, 34).</summary>
    public static Color Forest => new(34, 79, 34);

    /// <summary>Gets the metallic gold color (212, 175, 55).</summary>
    public static Color GoldMetallic => new(212, 175, 55);
    /// <summary>Gets the metallic silver color (192, 192, 192).</summary>
    public static Color SilverMetallic => new(192, 192, 192);
    /// <summary>Gets the bronze color (205, 127, 50).</summary>
    public static Color Bronze => new(205, 127, 50);
    /// <summary>Gets the copper color (184, 115, 51).</summary>
    public static Color Copper => new(184, 115, 51);
    /// <summary>Gets the brass color (181, 166, 66).</summary>
    public static Color Brass => new(181, 166, 66);

    /// <summary>Gets the Alice blue web color (240, 248, 255).</summary>
    public static Color AliceBlueWeb => new(240, 248, 255);
    /// <summary>Gets the antique white color (250, 235, 215).</summary>
    public static Color AntiqueWhite => new(250, 235, 215);
    /// <summary>Gets the aqua color (0, 255, 255).</summary>
    public static Color Aqua => new(0, 255, 255);
    /// <summary>Gets the beige color (245, 245, 220).</summary>
    public static Color Beige => new(245, 245, 220);
    /// <summary>Gets the bisque color (255, 228, 196).</summary>
    public static Color Bisque => new(255, 228, 196);
    /// <summary>Gets the blanched almond color (255, 235, 205).</summary>
    public static Color BlanchedAlmond => new(255, 235, 205);
    /// <summary>Gets the blue violet web color (138, 43, 226).</summary>
    public static Color BlueVioletWeb => new(138, 43, 226);
    /// <summary>Gets the cornsilk color (255, 248, 220).</summary>
    public static Color Cornsilk => new(255, 248, 220);
    /// <summary>Gets the floral white color (255, 250, 240).</summary>
    public static Color FloralWhite => new(255, 250, 240);
    /// <summary>Gets the gainsboro color (220, 220, 220).</summary>
    public static Color Gainsboro => new(220, 220, 220);
    /// <summary>Gets the ghost white color (248, 248, 255).</summary>
    public static Color GhostWhite => new(248, 248, 255);
    /// <summary>Gets the honeydew color (240, 255, 240).</summary>
    public static Color Honeydew => new(240, 255, 240);
    /// <summary>Gets the ivory color (255, 255, 240).</summary>
    public static Color Ivory => new(255, 255, 240);
    /// <summary>Gets the lavender blush color (255, 240, 245).</summary>
    public static Color LavenderBlush => new(255, 240, 245);
    /// <summary>Gets the linen color (250, 240, 230).</summary>
    public static Color Linen => new(250, 240, 230);
    /// <summary>Gets the mint cream color (245, 255, 250).</summary>
    public static Color MintCream => new(245, 255, 250);
    /// <summary>Gets the misty rose color (255, 228, 225).</summary>
    public static Color MistyRose => new(255, 228, 225);
    /// <summary>Gets the Navajo white color (255, 222, 173).</summary>
    public static Color NavajoWhite => new(255, 222, 173);
    /// <summary>Gets the old lace color (253, 245, 230).</summary>
    public static Color OldLace => new(253, 245, 230);
    /// <summary>Gets the seashell color (255, 245, 238).</summary>
    public static Color Seashell => new(255, 245, 238);
    /// <summary>Gets the snow color (255, 250, 250).</summary>
    public static Color Snow => new(255, 250, 250);
    /// <summary>Gets the wheat color (245, 222, 179).</summary>
    public static Color Wheat => new(245, 222, 179);
    /// <summary>Gets the white smoke color (245, 245, 245).</summary>
    public static Color WhiteSmoke => new(245, 245, 245);
}
