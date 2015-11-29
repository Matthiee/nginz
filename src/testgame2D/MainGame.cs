﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nginz;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace testgame2D {
	class MainGame : Game {

		ShaderProgram shader;
		SpriteBatch batch;
		Texture2D test;

		public MainGame (GameConfiguration conf) 
			: base (conf) { }

		protected override void Initialize () {
			base.Initialize ();

			batch = new SpriteBatch ();

			test = Content.Load<Texture2D> ("classical_ruin_tiles_1.png", TextureConfiguration.Nearest);
		}

		protected override void Resize () {
			base.Resize ();
		}

		protected override void Update (GameTime time) {

			// Exit if escape is pressed
			if (Keyboard.IsKeyTyped (Key.Escape))
				Exit ();

			base.Update (time);
		}

		protected override void Draw (GameTime time) {
			GL.ClearColor (.25f, .30f, .35f, 1f);
			GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			batch.Begin ();
			batch.Draw (test, Vector2.Zero, Color4.White, new Vector2 (2));
			batch.End ();

			base.Draw (time);
		}
	}
}
