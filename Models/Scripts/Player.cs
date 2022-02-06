using UnityEngine;

namespace Assets.Scripts {
	class Player : MonoBehaviour {
		private int grade;

		public string LetterGrade {
			get {
				if( grade > 100 )
					return "S";
				if( grade >= 97 )
					return "A+";
				if( grade >= 94 )
					return "A";
				if( grade >= 90 )
					return "A-";
				if( grade >= 87 )
					return "B+";
				if( grade >= 84 )
					return "B";
				if( grade >= 80 )
					return "B-";
				if( grade >= 77 )
					return "C+";
				if( grade >= 74 )
					return "C";
				if( grade >= 70 )
					return "C-";
				if( grade >= 67 )
					return "D+";
				if( grade >= 64 )
					return "D";
				return "F";
			}
		}

		public int Grade { get; set; }

		public int Birdiness { get; set; }
	}
}