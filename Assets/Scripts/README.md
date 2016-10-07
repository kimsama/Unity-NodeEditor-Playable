# Simple Node Editor

아래는 기본적인 폴더 및 중요한 파일들에 대한 설명입니다. 

* `Editor/NodeEditor`
  * NodeEditorWindow.cs - 최상위 클래스
  * Resources/ - 캐시 파일을 저장하는 폴더. 
* `Node_Editor/Framework`
  * Node.cs - 모든 노드들이 상속하는 최상위 클래스. 
  * Node/ - 개별 노드 클래스들을 포함하는 폴더.
* `Node_Editor/Resources/Save/` - 편집한 노드들을 포함하는 캔버스 파일(ScriptableObject)을 저장하는 폴더
* `Node_Editor/`
  * RuntimeNodeEditor.cs - GameObject에 추가, Play 모드시 노드 편집기의 작동을 위한 인터페이스를 제공. 