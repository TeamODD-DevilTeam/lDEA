public enum BlockType {
        Normal, // 기본값. 알파의 근거리 공격으로만 파괴 가능
        Mark, // 베타의 일반 원거리 공격으로만 파괴 가능
        Grass, // 베타의 불 속성 원거리 공격으로만 파괴 가능
        Agate // 알파 강공격으로 gate가 부숴집니다.
};

public enum ElementType {
    None, // 기본값. 아무런 속성도 없습니다.
    Fire, // 불 타입
    Grass, // 풀 타입
    Electrics // 전기 타입
};