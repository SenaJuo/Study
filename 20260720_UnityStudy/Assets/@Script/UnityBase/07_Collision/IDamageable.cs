using UnityEngine;


public interface IDamageable
{
    /* 인터페이스의 특징
     * 함수정의를 할 수 없음
     * 함수의 반환값, 접근제한자, 이름, 입력만 가능
     * 
     * 
     * 인터페이스를 상속받으면
     * 그 안에 있는 함수를 무조건 구현해야함
    */
    public void OnDamaged();
}
