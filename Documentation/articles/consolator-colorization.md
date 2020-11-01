# Consolator Colorization

Look, it's not the 1970's anymore. Color terminals have been around for a long time and colorizing your console app should be easy. This is especially critical as console apps have made quite the resurgence in recent years. **Consolator** makes this easy.

# [C#](#tab/cs)

~~~~csharp
Console.WriteLine("Hello from Consolator!", Color.Blue, Color.RGB(255, 255, 255));
~~~~

# [VB](#tab/cs)

~~~~vbnet
Console.WriteLine("Hello from Consolator!", Color.Blue, Color.RGB(255, 255, 255))
~~~~

# [F#](#tab/fs)

~~~~fsharp
// Not implemented yet
~~~~

***

Yup. Seriously, it's that easy.

You can also apply the color as a state through the `Foreground.Color` and `Background.Color` properties. This allows you to omit repeatedly passing the same colors into the functions over and over again. The two systems even work together, where if you set a color as a state, and pass colors to a function, the text written in that function will be colored as stated, and will return back to the state color. Clearing the state is as simple as passing `null` to the property.

## Color

So what is supported as far as color goes? Technically the only thing publicly visible is `Color` but that's an abstract class, so clearly there's some internal details. `Color` provides everything you need to hide these details. When you used a named color, like `Color.Black`, you actually get back a `SimpleColor` which acts as the basic 8-color system all color terminals support. This is the closest analogue to .NET's `ConsoleColor` enumeration. However, you can also construct colors through various factories like `Color.RGB(Byte, Byte, Byte)`. When one of these colors is used, it instead passes the 24-bit RGB escape sequence to the terminal, and, if supported, will display 24-bit color. You don't need to do anything different to make all this work.