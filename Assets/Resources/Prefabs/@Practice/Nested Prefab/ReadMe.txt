Nested Prefab 이란?
 - Prefab 안에 중첩된 Prefab이 존재하는 것.

(Nested : 중첩된) + (Prefab : Pre-Fabrication)

관계도.

-  PrefabA
-  PrefabB

-  Nested Prefab
   - PrefabB
   - PrefabA

위와 같은 구성도이다.
여기서 중요한 것은,
PrefabA나 PrefabB의 내용을 수정할 경우,
해당 내용은 Nested Prefab 안에 존재하는 PrefabA와 PrefabB에도
영향을 끼친다는 점이다.