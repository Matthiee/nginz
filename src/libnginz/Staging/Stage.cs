﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using nginz.Common;
using nginz.Staging.Interfaces;

namespace nginz.Staging {
	public class Stage : DynamicObject, ICanThrow {
		public List<IDraw> Drawings = new List<IDraw> ();
		public List<IActor> Actors = new List<IActor> ();
		public List<IAction> Actions = new List<IAction> ();

		public Dictionary<string, object> Properties = new Dictionary<string, object> ();

		Game game;

		public Stage (Game game) {
			this.game = game;
		}

		public void AddActor (IActor actor) {
			actor.Stage = this;
			actor.Initialize (game.Content);
			Actors.Add (actor);
		}
		public void AddDrawing (IDraw drawing) {
			Drawings.Add (drawing);
		}
		public void AddAction (IAction action) {
			Actions.Add (action);
		}

		public void Act (GameTime time) {
			Actors.ForEach (x => x.Action (time, game.Keyboard, game.Mouse));
			Actions.ForEach (x => x.Action (time, game.Keyboard, game.Mouse));
		}
		public void Draw (GameTime time, SpriteBatch batch) {
			Drawings.ForEach (x => x.Draw (time, batch));
			Actors.ForEach (x => x.Draw (time, batch));
		}

		public override bool TryGetMember (GetMemberBinder binder, out object result) {
			return Properties.TryGetValue (binder.Name, out result);
		}
		public override bool TrySetMember (SetMemberBinder binder, object value) {
			Properties[binder.Name] = value;
			
			return true;
		}
	}
}
