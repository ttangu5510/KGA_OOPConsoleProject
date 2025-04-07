# KGA_OOPConsoleProject
 > ConsoleProject for portfolio
 
 ## 프로젝트 설계
  - 지금까지 배웠떤 내용들을 토대로, 간단한 콘솔 게임을 만들어보는 프로젝트다
  - 레퍼런스는 MUD게임, 로그(1980) 와 같은 콘솔창 게임들이다.
  - 크게 `객체지향`, `자료구조`, `알고리즘`을 활용해서 보여줄 수 있는 프로젝트를 지향하도록 한다
 ## 기획
  - 일전에 배웠던 [소코반 기반  콘솔프로젝트](https://velog.io/@ttangu5510/C-14.-%EC%BD%98%EC%86%94-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B83-%EC%A7%81%EC%A0%91-%EB%A7%8C%EB%93%A4%EA%B8%B0)([깃허브](https://github.com/ttangu5510/Console_Project_Dungeon_Invade))와, [텍스트RPG 콘솔프로젝트](https://github.com/ttangu5510/TextRPG_example) 컨텐츠들을 합쳐서 구현해 보도록 한다
  - 소코반처럼 캐릭터의 움직임이 있고, 텍스트알피지 처럼 여러가지 선택사항에 따라 게임이 업데이트 될 수 있게 한다
  - 맵 생성은 로그와 같이 랜덤 맵생성을 목표로 해본다
	### 스프린트 백로그
	1. 선택지 : 씬
	1. 씬 전환, 동작 수행 : 게임매니저
	1. 플레이어 : 기본스탯, 장비, 인벤토리, 스킬
	1. 필드 맵 : 상호작용 가능 요소(문, 상자), 몬스터, 움직임
	1. 몬스터 : 다양한 몬스터, 전투 시스템
	1. 아이템 : 상점, 효과
	
	### 기본
	- 1. 선택지 : 씬 
	- 2. 씬 전환, 동작 수행 : 게임 매니저
	### 응용
	- 1. 플레이어 : 기본스텟
	- 2. 몬스터 : 전투 시스템
	- 3. 아이템 : 효과
	- 4. 필드 맵 : 몬스터
	### 도전
	- 1. 플레이어 : 인벤토리, 스킬
	- 2. 필드 맵 : 상호작용 가능 요소(문, 상자), 몬스터 움직임
	- 3. 몬스터 : 다양한 몬스터
	- 4. 아이템 : 상점
 ## 구조설계

