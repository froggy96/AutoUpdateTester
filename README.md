# AutoUpdateTester

C#/Winform 샘플 프로그램을 하나 만들고 거기에 자동 업데이트를 적용하도록 해 보겠다.

사용한 너겟: https://github.com/ravibpatel/AutoUpdater.NET
샘플프로그램 (this git) : https://github.com/froggy96/AutoUpdateTester

0. 우선 AutoUpdate 를 하려면 Application 파일들을 (.exe 및 .dll 과 기타 파일들)
zip 으로 묶어서 다운로드 받을 수 있는 웹서버를 마련해서 파일을 미리 올려 두어야 한다.
나는 로컬에 XAMPP 를 설치해서 테스트 하였다.
(여기서는 XAMPP 설치 및 사용법 등에 대한 설명은 하지 않겠다)

자, 웹서버는 준비된 것으로 치고,

1. Visual Studio 를 사용해서 C#, Winform App 을 하나 만든다.

2. 만들어진 App의 *.csproj 파일을 에디터로 연다.

3. XML 파일이 보일건데, Deterministic 이라는 필드를 찾는다. true 로 되어 있을 것이다. 이것을 false 로 바꾼다.

4. 저장하고 VS 로 돌아오면 아마도 csproj 파일이 변경되었으니 다시 로드할 것이냐 물을 것이다. Reload All 선택한다.

5. 솔루션 탐색기에서 Project/Properties/AssemblyInfo.cs 파일을 선택한다.

6. 맨 아래 부분에서 다음을 찾아...

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

아래와 같이 바꾼다. (두번째 라인은 커멘트 처리한 것이다)

[assembly: AssemblyVersion("1.0.*")]
// [assembly: AssemblyFileVersion("1.0.0.0")]

7. 컴파일 해 본다. 에러가 없으면 준비가 되었다.
이렇게 되면 매번 빌드할 때마다 Version Number 가 바뀌게 된다.
Version Number 의 구성은

1.0.x.y 로 생기게 되는데
x: Build Number, 하루에 1씩 증가
y: Revision Number, 오전 00:00:00 기준으로 2초 지날 때마다 1씩 증가.
==> 매번 빌드할 때마다 달라지게 된다.


8. 샘플 App 에서 아래 코드를 사용하면 빌드할 때마다 달라지는 버전을 확인할 수 있다.
(tbVersion 이라고 이름 붙여진 TextBox를 하나 Form 에 추가하고, 아래 코드로 확인)

  tbVersion.Text = $"{System.Windows.Forms.Application.ProductVersion}";

9. 이제 AutoUpdater를 적용하기 위해 nuget 을 하나 설치한다.

PM> Install-Package Autoupdater.NET.Official

10. AutoUpdater 가 일을 하게 하는 순서는 다음과 같다.

1) 샘플 App 의 Program.cs 에서 실행시키는 폼 (Application.Run 에서 실행하는 폼) 을 시작폼이라고 하자.

2) 시작폼의 .cs 파일에서 using 을 하나 더해 준다.
using AutoUpdaterDotNET;

3) 시작폼의 .cs 파일에 있는 생성자 함수의 맨 마지막에 아래 줄을 삽입한다.

AutoUpdater.Start("http://localhost/xml파일을찾아가는경로/autoupdate.xml");

4) autoupdate.xml (파일명은 다르게 해도 상관은 없다) 를 만들어서 웹서버의 해당 경로에 올려둔다.

<?xml version="1.0" encoding="UTF-8"?>
<item>
  <version>1.0.7948.18732</version>
  <url>http://localhost/프로그램zip파일까지경로/AutoUpdateTester.zip</url>
  <changelog>http://localhost/릴리즈정보를보여줄경로/releases.php</changelog>
  <mandatory>true</mandatory>
</item>

-version 은 zip 을 묶인 App 의 빌드번호를 알아내서 적어준다.
-mandatory 는 true 로 하면 "skip" 이나 "remind me later" 버튼을 감추고 "update" 버튼만 보여준다 (근데 여전히 사용자는 업데이트 폼을 그냥 끌 수 있다...오른쪽 위 x 버튼으로)
