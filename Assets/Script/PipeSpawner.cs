using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    //Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown, gateUp, gateDown;
    [SerializeField] private float spawnInterval;
    [SerializeField] public float holeSize;
    [SerializeField] private float maxMinOffset;
    [SerializeField] private Point point;
    //variable penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;
    private void Start()
    {
        // Memulai Spawning 
        StartSpawn();
    }
    void StartSpawn()
    {
        //Menjalankan Fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Menhentikan Coroutine IeSpawn jika sebeumnya sudah di jalankan
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //menduplikasi game object gateup dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
        Pipe newGateUp = Instantiate(gateUp, transform.position, Quaternion.Euler(0, 0, 180));

        //Mengaktifkan game object newGateUp
        newGateUp.gameObject.SetActive(true);

        //menduplikasi game object gateDown dan menempatkan posisinya sama dengan game object
        Pipe newGateDown = Instantiate(gateDown, transform.position, Quaternion.identity);

        //Mengaktifkan game object newGateDown
        newGateDown.gameObject.SetActive(true);

        //menduplikasi game object pipeUp dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        //Mengaktifkan game object newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //menduplikasi game object pipeDown dan menempatkan posisinya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //Mengaktifkan game object newPipeUp
        newPipeDown.gameObject.SetActive(true);


        //menempatkan posisi pipa yang telah dibentuk agar posisinya menyesuaikan dengan fungsi Sin
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;
        newGateUp.transform.position += Vector3.up * y;
        newGateDown.transform.position += Vector3.up * y;

        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //Jika Burung mati maka menhentikan pembuatan Pipa Baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            maxMinOffset = Random.Range(0f, 3f);
            holeSize = Random.Range(1f, 3f);
            spawnInterval = Random.Range(3f, 4f);
            //Membuat Pipa Baru
            SpawnPipe();

            //Menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
