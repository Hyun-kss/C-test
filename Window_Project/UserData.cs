using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Window_Project
{
    internal class UserData
    {
        // 사용자 포인트를 저장하는 static 변수
        private static int _userPoints = 10000; // 초기 포인트는 10000원
        // 포인트 변경 이벤트
        public static event Action<int> PointsChanged;
        // 포인트 프로퍼티
        public static int UserPoints
        {
            get => _userPoints;
            set
            {
                _userPoints = value;
                PointsChanged?.Invoke(_userPoints); // 포인트 변경 시 이벤트 호출
            }
        }
    }
}
