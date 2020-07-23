using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed = 5; // максимальная скорость корабля в секунду
    public float speedDamping = 0.1f; // дампинг скорости

    public float rotationSpeed = 90; // максимальный поворот в секунду
    public float rotationDamping = 0.1f; // дампинг вращения корпуса
    public float maxRotationAngle = 30f; // максимальный укол крена корпуса

    public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом)


    // значение вращения корпуса по умолчанию
    private Quaternion _shipDefaultRotation;

    // текущий поворот корпуса
    private float _shipRotation;
    // текущая скорость
    private float _shipSpeed;

    public void Start()
    {
        // сохраняем значение вращения корпуса по умолчанию
        _shipDefaultRotation = shipModel.localRotation;
    }

    public void Update()
    {
        // скорость корабля с дампингом
        _shipSpeed = Mathf.Lerp(_shipSpeed, Mathf.Max(Input.GetAxis("Vertical"), 0), speedDamping);
        // смещаем корабль в перед на нужную величину
        transform.position += transform.forward * _shipSpeed * speed * Time.deltaTime;

        var rot = Input.GetAxis("Horizontal");
        // вращаем корабль по оси Z
        transform.rotation *= Quaternion.AngleAxis(rot * rotationSpeed * Time.deltaTime, transform.up);

        // рассчитываем поврот корпуса корабля с дампингом
        _shipRotation = Mathf.Lerp(_shipRotation, -rot * maxRotationAngle, rotationDamping);
        // рассчитываем значение поворота корпуса
        shipModel.localRotation = _shipDefaultRotation * Quaternion.AngleAxis(_shipRotation, Vector3.right);

    }
}
