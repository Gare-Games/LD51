using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.classes
{
	public class Globals
	{
		public static Vector2 rotateRadians(Vector2 v, float radians)
		{
			return new Vector2(
					v.x * Mathf.Cos(radians) - v.y * Mathf.Sin(radians),
					v.x * Mathf.Sin(radians) + v.y * Mathf.Cos(radians)
			);
		}
		public static Vector2 rotate(Vector2 v, float degrees)
		{
			return rotateRadians(v, Mathf.Deg2Rad * degrees);
		}

		public enum Direction { up, down, left, right, upright, upleft, downleft, downright }
	}




}
