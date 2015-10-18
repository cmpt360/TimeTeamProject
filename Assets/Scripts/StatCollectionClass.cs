using UnityEngine;
using System.Collections;

public class StatCollectionClass : MonoBehaviour {

	//private int[] stats = new int[20];
	public struct StatCollection{
		public int health{
			get{return health;}
			set{health = value;}
		}

		public int mana{
			get{return mana;}
			set{mana = value;}
		}

		public int strength{
			get{return strength;}
			set{strength = value;}
		}

		public int intellect{
			get{return intellect;}
			set{intellect = value;}
		}

		public int xp{
			get{return xp;}
			set{xp = value;}
		}

		public int playerLevel{
			get{return playerLevel;}
			set{playerLevel = value;}
		}
	}
}

