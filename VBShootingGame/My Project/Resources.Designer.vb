﻿'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:4.0.30319.42000
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '이 클래스는 ResGen 또는 Visual Studio와 같은 도구를 통해 StronglyTypedResourceBuilder
    '클래스에서 자동으로 생성되었습니다.
    '멤버를 추가하거나 제거하려면 .ResX 파일을 편집한 다음 /str 옵션을 사용하여 ResGen을
    '다시 실행하거나 VS 프로젝트를 다시 빌드하십시오.
    '''<summary>
    '''  지역화된 문자열 등을 찾기 위한 강력한 형식의 리소스 클래스입니다.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  이 클래스에서 사용하는 캐시된 ResourceManager 인스턴스를 반환합니다.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("VBShootingGame.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  이 강력한 형식의 리소스 클래스를 사용하여 모든 리소스 조회에 대해 현재 스레드의 CurrentUICulture 속성을
        '''  재정의합니다.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property BackGround_0() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("BackGround_0", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.IO.MemoryStream과(와) 유사한 System.IO.UnmanagedMemoryStream 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Button_hover() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("Button_hover", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Destroy_0() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Destroy_0", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property E_Bullet() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("E_Bullet", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property E_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("E_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameInfo_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameInfo_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameInfo_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameInfo_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameInfo_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameInfo_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameOver() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameOver", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameQuit_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameQuit_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameQuit_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameQuit_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameQuit_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameQuit_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameSetting_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameSetting_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameSetting_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameSetting_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameSetting_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameSetting_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameStart_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameStart_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameStart_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameStart_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GameStart_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GameStart_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GoTitle_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GoTitle_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GoTitle_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GoTitle_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property GoTitle_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GoTitle_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.IO.MemoryStream과(와) 유사한 System.IO.UnmanagedMemoryStream 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Laser_one() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("Laser_one", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property P_Bullet() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("P_Bullet", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property P_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("P_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  =====================================
        '''
        '''    VB.Net Shooting Game By DH.IM    
        '''
        '''=====================================
        '''
        '''본 소프트웨어는 VB.Net을 활용하여 만든
        '''
        '''간단한 슈팅 게임입니다.  
        '''
        '''
        '''테스트 환경 : Microsoft Windows 8.1 64bit, x64 기반 프로세서
        '''
        '''
        '''조작키
        '''
        '''    모든 이동키는 한번 누르면 입력을 중지해도 방향을 유지 합니다.
        '''
        '''    방향을 바꾸려면 다른 방향의 키를, 멈추려면 정지 키를 누르세요.
        '''
        '''W : Up, Player 기체를 상단으로 이동
        '''
        '''A : Left, Player 기체를 좌측으로 이동
        '''
        '''S : Down, Player 기체를 하단으로 이동
        '''
        '''D : Right, Player 기체를 우측으로 이동
        '''
        '''F : Neutral, Player 기체 정지
        '''
        '''Space : Shoot, 탄을 발사합니다. 
        '''
        '''BackSp[나머지 문자열은 잘림]&quot;;과(와) 유사한 지역화된 문자열을 찾습니다.
        '''</summary>
        Friend ReadOnly Property ReadMe() As String
            Get
                Return ResourceManager.GetString("ReadMe", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Restart_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Restart_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Restart_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Restart_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Restart_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Restart_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Resume_Click() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Resume_Click", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Resume_Default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Resume_Default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Resume_Hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Resume_Hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  System.Drawing.Bitmap 형식의 지역화된 리소스를 찾습니다.
        '''</summary>
        Friend ReadOnly Property Title() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Title", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
