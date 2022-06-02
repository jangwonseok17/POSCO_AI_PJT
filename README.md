# VR 기기를 활용한 AI 사회자가 진행하는 가상세계 토론 플랫폼

## 1. 프로젝트 소개
- 추진 배경 및 목표 : 메타버스가 Digital Learning 플랫폼으로써 콘텐츠 활용 중심 학생 교육프로그램
의 기반이 되는 데 의의를 두고 진행됨
- 메타버스 : 현실과 유사 또는 완전히 다른 대안적 세계를 Digital Data로 구축한 것을 의미

## 2. 프로젝트 개요
![image](https://user-images.githubusercontent.com/83684431/171030294-bc278836-d232-4251-850a-853c8555b9f7.png)
메타버스 안에서 교육 플랫폼을 구현하는데 중심을 둠으로써 가상환경에서 토론을 진행하는데 목적을 두고 있다.
토론이 진행될 때 원활한 의사소통과 진행을 위한 사회자를 두는데, 이 토론에서 AI사회자는 발언 요약, 시간제제, 등의 역할을 한다.
### 2-1. AI 사회자
- 음성 발화 기능 : 패널의 발화 내용을 요약하여 발언 이 때 다양한 사람들의 목소리를 학습하여 사회자 음성으로 사용할 수 있도록 구현
- 패널 발화 요약 기능 : 패널의 발화 내용을 요약하여 변환된 텍스트를 음성으로 출력
- 규칙 위반 패널 제재 : 토론 중 비속어나 주제에 맞지 않는다고 판단 할 경우 패널 제재
- 패널 발언 시간 확인 및 제재 : 정해진 토론 시간을 초과해서 발화할 경우 이를 확인하고 제재

### 2-2. 사용 기술 소개
- Unity
- Socket 통신
- NLP

![image](https://user-images.githubusercontent.com/83684431/171031996-b8044897-525d-4c75-ac6c-05fe44ef176e.png)

## 3. 상세 기술 구현
### 3-1. Unity
- Unity : 가상 토론장 구현
- Oculus Quest2 : 가상 토론장에 참여할 수 있는 VR 기기
- XR Interaction Toolkit : Unity에서 개발한 가상세계를 VR, AR 기기와 상호작용할 수 있도록 데이터를 변환시키는 라이브러리
- Asset Store 내 Object : 토론장 내 의자, 마이크, 아바타 등
- Everyday Motion Pack Free : 토론장 내 청중 애니메이션 효과

### 3-2. Soket 통신
- Server 소켓은 Client 소켓의 신호를 대기 후 동일한 IP, 포트번호를 가진 Client 소켓이 신호를 보내면 연결
- 본 프로젝트에서는 Unity - Text Semmarization - TTS - Unity의 흐름으로 소켓 통신 구현

### 3-3. STT
- Google Speech To Text API : 한국어 STT 기능 제공 및 형태소 분리 가능 본 프로젝트에서는 Unity로 구축한 가상 토론장에서 음성 입력, 정지가 가능한 가상 패널을 만들고, 사용하였다.

![image](https://user-images.githubusercontent.com/83684431/171033216-16f68b7f-ceae-4dc8-b698-46e7c18b2b7f.png)

### 3-4. Text Summarization - SKT 공식 GitHub의 KoBart
![image](https://user-images.githubusercontent.com/83684431/171033503-d2e8467b-58da-4258-b393-7a6e8fa2597d.png)

본 프로젝트에서 구현하고자 하는 Text summarization은 Extractive 방식으로 토론자의 말을 그대로 인용해서 요약하는 것이 아닌, 실제 토론 현장의 사회자처럼 토론자가 전달하고자 하는 내용을 이해하고 문맥을 새롭게 재구성해서 summarization하는 것이다. 따라서 원문에 없던 단어나 문장을 사용하면서 핵심만 간추려서 표현하는 요약 방법이 요구되었으며, 이에 따Abstractive summarization을 구현

### 3-5. Train Dataset 생성
![image](https://user-images.githubusercontent.com/83684431/171033595-d240fc24-cb5d-4598-8009-8f52080d1151.png)
구글, 유튜브 등에서 토론 텍스트, 토론 영상을 참고하여 토론자의 발화문을 얻었으며, 사회자 요약문이 존재하는 경우에는 그것을 사용했고, 존재하지 않는 경우에는 직접 요약문을 만들어 학습 데이터를 생성

### 3-6. TTS - Tacotron2
- Tacotron2는 다양한 모델들이 존재하는데 본프로젝트에서는 NVIDIA에서 만든 Tacotron2를 사용
- 원본 NVIDIA 코드는 한국어를 지원하지 않기 때문에 한국어 전 처리 코드의 수정이 필요했다. 한국어 전처리에는 숫자, 특수문자, 영어 등을 한글로 변환하는 작업 뿐 만 아니라 음절로 되어 있는 단위를 음소로 변환하는 작업을 포함

### 3-7. WaveGlow Vocoder
- NVDIA에서 공개한 WaveGlow를 사용
- Tacotron2과 WaveGlow를 학습시키기 위해서 Kaggle에서 제공중인 KSS dataset을 사용하였다. KSS dataset은 전문 여성 성우가 Korean, Korean-english 사전 책 4권의 예문을 읽은 약 12시간 분량의 고품질 데이터셋으로 12,853개의 Audio clips으로 구성되어 있으며, 44,100Hz의 Sampling rate로 구성되어 있다. 이를 활용하여 기반으로 TTS 모델 구현에 성공




### References
Sequence to Sequence Learning with Neural Networks.
Ilya Sutskever, Oriol Vinyals, Quoc V. Le
BART: Denoising Sequence-to-Sequence Pre-training for Natural Language Generation,
Translation, and Comprehension.
Mike Lewis, Yinhan Liu, Naman Goyal, Marjan Ghazvininejad, Abdelrahman Mohamed, Omer Levy, Ves Stoyanov, Luke
Zettlemoyer
A Study On Learning Game Using An Unity 3D
Seok-Hyun Yoon
한국어 TTS 시스템에서 딥러닝 기반 최첨단 보코더 기술 성능 비교
Kwon, C. H. (2020). 문화기술의 융합, 6(2), 509–514. https://doi.org/10.17703/JCCT.2020.6.2.509
