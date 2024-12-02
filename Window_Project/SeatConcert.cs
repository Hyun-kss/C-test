using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Window_Project
{
    public partial class SeatConcert : Form
    { /// <summary>
    /// 좌석용의 구성을 위한 것들 
    /// </summary>
        private Timer seatTimer;  // 좌석 타이머
        private Random random = new Random();  // 랜덤 좌석 선택을 위한 객체
        public int totalSeats = 30;  // 총 좌석 수
        public List<Button> seatButtons = new List<Button>();  // 좌석 버튼 리스트
        public int availableSeats = 30;  // 사용 가능한 좌석 수
      
        
        private int userSelectedTickets = 0;  // 사용자가 선택한 티켓 수 , 환급 계산 용도
        private string difficulty;  // 선택된 난이도 


        //카운트 이벤트를 위한 것들 
        private bool isCountdownActive = true;  // 카운트다운 활성화 여부
        private Timer countdownTimer;  // 카운트다운 타이머
        private int countdown = 3;  // 카운트다운 초기값 (3초)
        // 난이도별 이벤트
        public static event EventHandler MediumModeUnlocked;
        public static event EventHandler HardModeUnlocked;
        public static event EventHandler ChaosModeUnlocked;

        // 생성자: 난이도에 따라 게임을 초기화
        public SeatConcert(string selectedDifficulty)
        {
            InitializeComponent();
            difficulty = selectedDifficulty;

            Console.WriteLine($"난이도: {difficulty}");  // 디버깅용 출력
            InitializeSeats();  // 좌석 초기화
            StartCountdown();  // 카운트다운 시작

            userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";  // 포인트 표시
        }

        // 카운트다운 시작
        private void StartCountdown()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;  // 1초마다 이벤트 발생
            countdownTimer.Tick += Countdown_Tick;
            countdownTimer.Start();

            DisableSeatButtons();  // 카운트다운 시작 시 좌석 비활성화
        }

        // 카운트다운이 진행될 때마다 호출되는 이벤트 숫자 
        private void Countdown_Tick(object sender, EventArgs e)
        {
            countdown--;  // 카운트다운 감소
            this.Invalidate();  // 폼 다시 그리기

            if (countdown == 0)
            {
                countdownTimer.Stop();  // 카운트다운 종료
                isCountdownActive = false;  // 카운트다운 종료 상태
                this.Invalidate();  // 폼 다시 그리기
                MessageBox.Show("좌석 점유 시작");
                StartSeatTimer();  // 좌석 타이머 시작

                EnableSeatButtons();  // 카운트다운 종료 후 좌석 활성화
            }
        }

        // 좌석 버튼을 활성화
        private void EnableSeatButtons()
        {
            foreach (var button in seatButtons)
            {
                button.Enabled = true;  // 버튼 활성화
            }
        }

        // 좌석 버튼을 비활성화
        private void DisableSeatButtons()
        {
            foreach (var button in seatButtons)
            {
                button.Enabled = false;  // 버튼 비활성화
            }
        }

        // 좌석을 초기화 (UI에 좌석 버튼 생성)
        private void InitializeSeats()
        {
            for (int i = 0; i < totalSeats; i++)
            {
                int seatPrice = GetSeatPrice();  // 난이도에 따른 좌석 가격 계산

                Button seatButton = new Button
                {
                    Text = $"좌석 {i + 1}",  // 좌석 번호 표시
                    Size = new Size(100, 50),
                    Location = new Point(10 + (i % 5) * 110, 10 + (i / 5) * 60),
                    BackColor = Color.LightGreen,  // 기본 배경색
                    Tag = seatPrice  // 좌석 가격을 Tag에 저장
                };

                Console.WriteLine($"좌석 {i + 1} 가격: {seatPrice}");  // 디버깅용 출력

                seatButton.Click += SeatButton_Click;  // 좌석 클릭 이벤트 처리
                seatButtons.Add(seatButton);
                this.Controls.Add(seatButton);  // 폼에 좌석 버튼 추가
            }
        }

        // 난이도별 좌석 가격 반환
        private int GetSeatPrice()
        {
            if (difficulty == "Medium")
            {
                return 3000;  // Medium모드 가격
            }
            else if (difficulty == "Hard")
            {
                return 5000;  // Hard모드 가격
            }
            else if (difficulty == "Chaos")
            {
                return 10000;  // Chaos모드 가격
            }
            else if (difficulty == "Easy")
            {
                return 2000;  // Easy모드 가격
            }
            else
            {
                return 2000;  // 기본값
            }
        }

        // 난이도에 따라 좌석 타이머 인터벌 반환
        private int GetSeatTimerInterval()
        {
            if (difficulty == "Chaos") return 10;
            else if (difficulty == "Hard") return 70;
            else if (difficulty == "Medium") return 100;
            else return 150;  // Easy 모드 기본값
        }

        // 좌석 타이머 시작
        private void StartSeatTimer()
        {
            seatTimer = new Timer();
            seatTimer.Interval = GetSeatTimerInterval();  // 난이도에 맞는 타이머 인터벌 설정
            seatTimer.Tick += delegate { ChangeSeatColors(); };  // 좌석 색상 변경
            seatTimer.Start();
        }

        // 좌석 색상 변경 (임의로 좌석을 '판매됨'으로 표시)
        private void ChangeSeatColors()
        {
            if (availableSeats > 0)
            {
                int seatIndex = random.Next(totalSeats);  // 임의의 좌석 선택

                if (seatButtons[seatIndex].BackColor != Color.Red)
                {
                    seatButtons[seatIndex].BackColor = Color.Red;  // 좌석 판매됨 상태
                    seatButtons[seatIndex].Text = "판매됨";  // 텍스트 변경
                    availableSeats--;  // 남은 좌석 수 감소
                }
            }

            if (availableSeats == 0)
            {
                seatTimer.Stop();  // 좌석 타이머 중지
                RefundPoints();  // 좌석 모두 판매 후 환불 처리
            }
        }

        // 좌석 버튼 클릭 시 처리 (좌석 가격 결제)
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // 이미 판매된 좌석이면 메시지 출력
            if (clickedButton.BackColor == Color.Red)
            {
                MessageBox.Show("이미 판매된 좌석입니다.");
                return;
            }

            // 좌석 가격 가져오기
            int seatPrice = (int)clickedButton.Tag;
            Console.WriteLine($"좌석 가격: {seatPrice}");  // 디버깅용

            // 유저 포인트 확인 후 결제 처리
            if (UserData.UserPoints >= seatPrice)
            {
                UserData.UserPoints -= seatPrice;  // 좌석 가격 차감
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";

                clickedButton.BackColor = Color.Red;  // 좌석 상태 변경
                clickedButton.Text = "판매됨";  // 텍스트 변경

                userSelectedTickets++;  // 선택된 티켓 수 증가

                MessageBox.Show("결제가 성공적으로 처리되었습니다!");  // 결제 완료 메시지
            }
            else
            {
                MessageBox.Show("포인트가 부족하여 결제할 수 없습니다.");  // 결제 실패 메시지
                RefundPoints();  // 결제 실패 시 환불 처리
                this.Close();  // 폼 종료
            }
        }

        // 결제 후 환불 처리
        private void RefundPoints()
        {
            if (userSelectedTickets > 0)
            {
                int refundAmount = userSelectedTickets * GetSeatPrice() * 2;  // 환불 금액 계산
                UserData.UserPoints += refundAmount;
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";
                MessageBox.Show($"성공적으로 구매한 {userSelectedTickets}장의 티켓에 대해 총 {refundAmount}원을 돌려드렸습니다.");
            }
            else
            {
                int penaltypoint = GetSeatPrice() * 2;
                UserData.UserPoints -= penaltypoint;  // 포인트 차감
                string message = $"구매한 티켓이 없어 환불이 진행되지 않았습니다.\n" +
                  $"참여에 실패하여 {penaltypoint} 포인트를 차감합니다.";
                MessageBox.Show(message);  // 실패 메시지
                this.Close();  // 폼 종료
            }
        }

        // Settle 버튼 클릭 시 결제 확정
        private void SettleButton_Click(object sender, EventArgs e)
        {
            if (userSelectedTickets > 0)
            {
                int refundAmount = userSelectedTickets * GetSeatPrice() * 2;  // 환불 금액 계산
                UserData.UserPoints += refundAmount;
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";
                MessageBox.Show($"구매한 {userSelectedTickets}장의 티켓에 대해 총 {refundAmount}원이 환급되었습니다.");
                this.Close();  // 폼 종료
            }
        }

        // 난이도에 따른 모드 잠금 해제 여부 체크
        public void CheckModeUnlock()
        {
            if (difficulty == "Easy" && UserData.UserPoints >= 20000)
            {
                MediumModeUnlocked?.Invoke(this, EventArgs.Empty);  // Medium 모드 잠금 해제
            }
            else if (difficulty == "Medium" && UserData.UserPoints >= 35000)
            {
                HardModeUnlocked?.Invoke(this, EventArgs.Empty);  // Hard 모드 잠금 해제
            }
            else if (difficulty == "Hard" && UserData.UserPoints >= 70000)
            {
                ChaosModeUnlocked?.Invoke(this, EventArgs.Empty);  // Chaos 모드 잠금 해제
            }
            else if (difficulty == "Chaos" && UserData.UserPoints >= 60000)
            {
                MessageBox.Show("축하합니다! Chaos 모드를 완료했습니다.");
                Application.Exit();  // 게임 종료
            }
        }

        // 폼에 카운트다운 텍스트 그리기
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isCountdownActive && countdown > 0)
            {
                Graphics g = e.Graphics;
                string text = countdown.ToString();
                Font font = new Font("Arial", 48, FontStyle.Bold);
                SizeF textSize = g.MeasureString(text, font);
                float textX = this.ClientSize.Width - textSize.Width - 10;
                float textY = 10;
                g.DrawString(text, font, Brushes.Black, textX, textY);
            }
        }

        // 폼 배경 그리기 (그라디언트 효과)
        private void SeatConcert_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.White, 45f);
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);  // 배경 그라디언트로 채우기
        }
    }


}

     


