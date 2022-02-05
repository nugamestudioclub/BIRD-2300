using UnityEngine;

namespace Assets.Scripts {
	class Player : MonoBehaviour {
		private int grade;

		public string LetterGrade => grade switch {
			> 100 => "S",
			(>= 97) and (<= 100) => "A+",
			(>= 94) and (< 97) => "A",
			(>= 90) and (< 94) => "A-",
			(>= 87) and (< 90) => "B+",
			(>= 84) and (< 87) => "B",
			(>= 80) and (< 83) => "B-",
			(>= 77) and (< 80) => "C+",
			(>= 74) and (< 77) => "C",
			(>= 70) and (< 73) => "C-",
			(>= 67) and (< 70) => "D+",
			(>= 64) and (< 67) => "D",
			_ => "F"
		};

		public int Grade { get; set; }

		public int Birdiness { get; set; }
	}
}