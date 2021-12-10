''' <summary>
''' This is the main type for your game
''' </summary>

public class Game1
    inherits Microsoft.Xna.Framework.Game
    private ScreenManager as ScreenManager
    public shared SongPlay as SoundEffectInstance
    public shared SongPlaying as Boolean = false
    public shared SongSetting as Integer
    public shared messageCounter = 1

    private DrawX as Integer
    private DrawY as Integer
    private DrawSize as Integer

    public sub new()
        Globals.Graphics = new GraphicsDeviceManager(me)
        Content.RootDirectory = "Content"
    end sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling MyBase.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
  
    protected overrides sub Initialize()
    
        ' TODO: Add your initialization logic here
    
        me.IsMouseVisible = true
        Window.AllowUserResizing = true

        Globals.GameSize = new Vector2(720, 720)
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y

        Globals.Graphics.ApplyChanges()

        Globals.BackBuffer = new RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)

        MyBase.Initialize()
    end sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
  
    protected overrides sub LoadContent()
    
        ' Create a new SpriteBatch, which can be used to draw textures.
    
        Globals.SpriteBatch = new SpriteBatch(GraphicsDevice)
        Globals.Content = me.Content

        'load fonts/textures/sound
    
        Fonts.Load()
        Textures.Load()
        Music.Load()

        'Add Default Screens ex. title screen
    
        ScreenManager = new ScreenManager()

        ScreenManager.AddScreen(new TitleScreen)
        'ScreenManager.AddScreen(new Mainmenu)

    end sub
  
    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>

    protected overrides sub Update(byval gameTime as GameTime)
    
        ' Allows the game to exit
    
        if Mainmenu.ExitGame = true then
            me.Exit()
        end if
    
        ' TODO: Add your update logic here
    
        MyBase.Update(gameTime)
        Globals.WindowFocused = me.IsActive
        Globals.GameTime = gameTime

        'update screens
    
        ScreenManager.Update()

        'Input Update
    
        Input.Update()

         if WorldScreen.MapSong >= 1 And WorldScreen.MapSong <= 5 And Mainmenu.InDialouge = false then
            if SongSetting <> 1 then
                try
                    SongPlay.Dispose()
                    SongPlaying = false
                catch
                end try
        
            end if

            if SongPlaying = false then
                SongPlay = Music.LowFloors.CreateInstance()
                SongPlay.IsLooped = true
                SongPlay.Play()
                SongPlaying = true
                SongSetting = 1
            end if
      
        elseif WorldScreen.MapSong >= 6 And WorldScreen.MapSong <= 13 And Mainmenu.InDialouge = false And WorldScreen.BossInitialize < 0 then

            if SongSetting <> 2 then
                try
                    SongPlay.Dispose()
                    SongPlaying = false
                catch
                end try
            end if

            if SongPlaying = false then
                SongPlay = Music.HighFLoors.CreateInstance()
                SongPlay.IsLooped = true
                SongPlay.Play()
                SongPlaying = true
                SongSetting = 2
            end if
      
        elseif Mainmenu.InDialouge = true And WorldScreen.MapSong <> 0 then
            if SongSetting <> 3 then
                try
                    SongPlay.Dispose()
                    SongPlaying = false
                catch
                end try
            end if
            if SongPlaying = false then
                SongPlay = Music.Dialouge.CreateInstance()
                SongPlay.IsLooped = true
                SongPlay.Play()
                SongPlaying = true
                SongSetting = 3
            end if
      
        elseif Mainmenu.InDialouge = false And WorldScreen.BossInitialize >= 0 then
            if SongSetting <> 4 then
                try
                    SongPlay.Dispose()
                    SongPlaying = false
                catch
                end try
            end if
            if SongPlaying = false then
                SongPlay = Music.Boss.CreateInstance()
                SongPlay.IsLooped = true
                SongPlay.Play()
                SongPlaying = true
                SongSetting = 4
            end if
      
        elseif WorldScreen.MapSong = 0 then
                SongPlaying = false

        end if

    end sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
  
    protected overrides sub Draw(byval gameTime as GameTime)
        Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer)
        GraphicsDevice.Clear(Color.Black)
        mybase.Draw(gameTime)

        'Draw Contents Of Screen Manager
    
        ScreenManager.Draw()

        Globals.Graphics.GraphicsDevice.SetRenderTarget(nothing)

        'Draw BackBuffer
        Globals.SpriteBatch.Begin()
        'Globals.SpriteBatch.Draw(Globals.BackBuffer, new Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), Color.White)

        if Globals.Graphics.GraphicsDevice.Viewport.Width > Globals.Graphics.GraphicsDevice.Viewport.Height then
            DrawSize = Globals.Graphics.GraphicsDevice.Viewport.Height
        elseif Globals.Graphics.GraphicsDevice.Viewport.Width < Globals.Graphics.GraphicsDevice.Viewport.Height
            DrawSize = Globals.Graphics.GraphicsDevice.Viewport.Width
        else
            DrawSize = Globals.Graphics.GraphicsDevice.Viewport.Height
        end if

        DrawX = (Globals.Graphics.GraphicsDevice.Viewport.Width - DrawSize) / 2
        DrawY = (Globals.Graphics.GraphicsDevice.Viewport.Height - DrawSize) / 2

        Globals.SpriteBatch.Draw(Textures.SpriteSheet1, new Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), new Rectangle(0, 0, 1, 1), Color.White)

        Globals.SpriteBatch.Draw(Globals.BackBuffer, new Rectangle(DrawX, DrawY, DrawSize, DrawSize), Color.White)

        Globals.SpriteBatch.end()
    end sub


end class
