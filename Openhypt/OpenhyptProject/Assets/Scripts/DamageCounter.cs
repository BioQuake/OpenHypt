using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DamageCounter : MonoBehaviour
{
    public static DamageCounter instance;
    public Transform thisTransform;
    public Transform Title;
    public bool Up;
    public Transform TC0;
    public Renderer TC0r;
    public bool TC0f;
    public static float TC0Amount;
    public TextMesh TC0Text;
    public bool TC0Up;
    public Transform TC2;
    public Renderer TC2r;
    public bool TC2f;
    public static float TC2Amount;
    public TextMesh TC2Text;
    public bool TC2Up;
    public Transform TC3;
    public Renderer TC3r;
    public bool TC3f;
    public static float TC3Amount;
    public TextMesh TC3Text;
    public bool TC3Up;
    public Transform TC4;
    public Renderer TC4r;
    public bool TC4f;
    public static float TC4Amount;
    public TextMesh TC4Text;
    public bool TC4Up;
    public Transform TC5;
    public Renderer TC5r;
    public bool TC5f;
    public static float TC5Amount;
    public TextMesh TC5Text;
    public bool TC5Up;
    public Transform TC6;
    public Renderer TC6r;
    public bool TC6f;
    public static float TC6Amount;
    public TextMesh TC6Text;
    public bool TC6Up;
    public Transform TC7;
    public Renderer TC7r;
    public bool TC7f;
    public static float TC7Amount;
    public TextMesh TC7Text;
    public bool TC7Up;
    public Transform TC8;
    public Renderer TC8r;
    public bool TC8f;
    public static float TC8Amount;
    public TextMesh TC8Text;
    public bool TC8Up;
    public Transform TC9;
    public Renderer TC9r;
    public bool TC9f;
    public static float TC9Amount;
    public TextMesh TC9Text;
    public bool TC9Up;
    public virtual void Awake()
    {
        DamageCounter.instance = this;
    }

    public virtual void Start()
    {
        this.thisTransform = this.transform;
        if (!WorldInformation.DamageCounterOff)
        {
            if (DamageCounter.TC0Amount > 0)
            {
                this.UpdateDamage(0);
            }
            if (DamageCounter.TC2Amount > 0)
            {
                this.UpdateDamage(2);
            }
            if (DamageCounter.TC3Amount > 0)
            {
                this.UpdateDamage(3);
            }
            if (DamageCounter.TC4Amount > 0)
            {
                this.UpdateDamage(4);
            }
            if (DamageCounter.TC5Amount > 0)
            {
                this.UpdateDamage(5);
            }
            if (DamageCounter.TC6Amount > 0)
            {
                this.UpdateDamage(6);
            }
            if (DamageCounter.TC7Amount > 0)
            {
                this.UpdateDamage(7);
            }
            if (DamageCounter.TC8Amount > 0)
            {
                this.UpdateDamage(8);
            }
            if (DamageCounter.TC9Amount > 0)
            {
                this.UpdateDamage(9);
            }
        }
        else
        {

            {
                float _1244 = this.thisTransform.localPosition.x - 2;
                Vector3 _1245 = this.thisTransform.localPosition;
                _1245.x = _1244;
                this.thisTransform.localPosition = _1245;
            }
        }
    }

    public virtual void Update()
    {
        if (this.TC0f)
        {
            if (this.TC0r.material.color.a > 0)
            {

                {
                    float _1246 = this.TC0r.material.color.a - 0.01f;
                    Color _1247 = this.TC0r.material.color;
                    _1247.a = _1246;
                    this.TC0r.material.color = _1247;
                }
            }
            else
            {
                this.TC0f = false;
            }
        }
        if (this.TC2f)
        {
            if (this.TC2r.material.color.a > 0)
            {

                {
                    float _1248 = this.TC2r.material.color.a - 0.01f;
                    Color _1249 = this.TC2r.material.color;
                    _1249.a = _1248;
                    this.TC2r.material.color = _1249;
                }
            }
            else
            {
                this.TC2f = false;
            }
        }
        if (this.TC3f)
        {
            if (this.TC3r.material.color.a > 0)
            {

                {
                    float _1250 = this.TC3r.material.color.a - 0.01f;
                    Color _1251 = this.TC3r.material.color;
                    _1251.a = _1250;
                    this.TC3r.material.color = _1251;
                }
            }
            else
            {
                this.TC3f = false;
            }
        }
        if (this.TC4f)
        {
            if (this.TC4r.material.color.a > 0)
            {

                {
                    float _1252 = this.TC4r.material.color.a - 0.01f;
                    Color _1253 = this.TC4r.material.color;
                    _1253.a = _1252;
                    this.TC4r.material.color = _1253;
                }
            }
            else
            {
                this.TC4f = false;
            }
        }
        if (this.TC5f)
        {
            if (this.TC5r.material.color.a > 0)
            {

                {
                    float _1254 = this.TC5r.material.color.a - 0.01f;
                    Color _1255 = this.TC5r.material.color;
                    _1255.a = _1254;
                    this.TC5r.material.color = _1255;
                }
            }
            else
            {
                this.TC5f = false;
            }
        }
        if (this.TC6f)
        {
            if (this.TC6r.material.color.a > 0)
            {

                {
                    float _1256 = this.TC6r.material.color.a - 0.01f;
                    Color _1257 = this.TC6r.material.color;
                    _1257.a = _1256;
                    this.TC6r.material.color = _1257;
                }
            }
            else
            {
                this.TC6f = false;
            }
        }
        if (this.TC7f)
        {
            if (this.TC7r.material.color.a > 0)
            {

                {
                    float _1258 = this.TC7r.material.color.a - 0.01f;
                    Color _1259 = this.TC7r.material.color;
                    _1259.a = _1258;
                    this.TC7r.material.color = _1259;
                }
            }
            else
            {
                this.TC7f = false;
            }
        }
        if (this.TC8f)
        {
            if (this.TC8r.material.color.a > 0)
            {

                {
                    float _1260 = this.TC8r.material.color.a - 0.01f;
                    Color _1261 = this.TC8r.material.color;
                    _1261.a = _1260;
                    this.TC8r.material.color = _1261;
                }
            }
            else
            {
                this.TC8f = false;
            }
        }
        if (this.TC9f)
        {
            if (this.TC9r.material.color.a > 0)
            {

                {
                    float _1262 = this.TC9r.material.color.a - 0.01f;
                    Color _1263 = this.TC9r.material.color;
                    _1263.a = _1262;
                    this.TC9r.material.color = _1263;
                }
            }
            else
            {
                this.TC9f = false;
            }
        }
    }

    public virtual void ShowDamage(float Amount, int Code)
    {
        if (!this.Up)
        {
            this.Up = true;

            {
                float _1264 = this.Title.localPosition.y + 10;
                Vector3 _1265 = this.Title.localPosition;
                _1265.y = _1264;
                this.Title.localPosition = _1265;
            }
        }
        if (Code == 0)
        {
            if (!this.TC0Up)
            {
                this.TC0Up = true;

                {
                    float _1266 = this.TC0.localPosition.y + 10;
                    Vector3 _1267 = this.TC0.localPosition;
                    _1267.y = _1266;
                    this.TC0.localPosition = _1267;
                }

                {
                    float _1268 = this.Title.localPosition.y + 1;
                    Vector3 _1269 = this.Title.localPosition;
                    _1269.y = _1268;
                    this.Title.localPosition = _1269;
                }
                if (this.TC2Up)
                {

                    {
                        float _1270 = this.TC2.localPosition.y + 1;
                        Vector3 _1271 = this.TC2.localPosition;
                        _1271.y = _1270;
                        this.TC2.localPosition = _1271;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1272 = this.TC3.localPosition.y + 1;
                        Vector3 _1273 = this.TC3.localPosition;
                        _1273.y = _1272;
                        this.TC3.localPosition = _1273;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1274 = this.TC4.localPosition.y + 1;
                        Vector3 _1275 = this.TC4.localPosition;
                        _1275.y = _1274;
                        this.TC4.localPosition = _1275;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1276 = this.TC5.localPosition.y + 1;
                        Vector3 _1277 = this.TC5.localPosition;
                        _1277.y = _1276;
                        this.TC5.localPosition = _1277;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1278 = this.TC6.localPosition.y + 1;
                        Vector3 _1279 = this.TC6.localPosition;
                        _1279.y = _1278;
                        this.TC6.localPosition = _1279;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1280 = this.TC7.localPosition.y + 1;
                        Vector3 _1281 = this.TC7.localPosition;
                        _1281.y = _1280;
                        this.TC7.localPosition = _1281;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1282 = this.TC8.localPosition.y + 1;
                        Vector3 _1283 = this.TC8.localPosition;
                        _1283.y = _1282;
                        this.TC8.localPosition = _1283;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1284 = this.TC9.localPosition.y + 1;
                        Vector3 _1285 = this.TC9.localPosition;
                        _1285.y = _1284;
                        this.TC9.localPosition = _1285;
                    }
                }
            }

            {
                float _1286 = 0.5f;
                Color _1287 = this.TC0r.material.color;
                _1287.a = _1286;
                this.TC0r.material.color = _1287;
            }
            this.TC0f = true;
            DamageCounter.TC0Amount = DamageCounter.TC0Amount + Amount;
            this.TC0Text.text = Mathf.RoundToInt(DamageCounter.TC0Amount).ToString();
        }
        if (Code == 2)
        {
            if (!this.TC2Up)
            {
                this.TC2Up = true;

                {
                    float _1288 = this.TC2.localPosition.y + 10;
                    Vector3 _1289 = this.TC2.localPosition;
                    _1289.y = _1288;
                    this.TC2.localPosition = _1289;
                }

                {
                    float _1290 = this.Title.localPosition.y + 1;
                    Vector3 _1291 = this.Title.localPosition;
                    _1291.y = _1290;
                    this.Title.localPosition = _1291;
                }
                if (this.TC0Up)
                {

                    {
                        float _1292 = this.TC0.localPosition.y + 1;
                        Vector3 _1293 = this.TC0.localPosition;
                        _1293.y = _1292;
                        this.TC0.localPosition = _1293;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1294 = this.TC3.localPosition.y + 1;
                        Vector3 _1295 = this.TC3.localPosition;
                        _1295.y = _1294;
                        this.TC3.localPosition = _1295;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1296 = this.TC4.localPosition.y + 1;
                        Vector3 _1297 = this.TC4.localPosition;
                        _1297.y = _1296;
                        this.TC4.localPosition = _1297;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1298 = this.TC5.localPosition.y + 1;
                        Vector3 _1299 = this.TC5.localPosition;
                        _1299.y = _1298;
                        this.TC5.localPosition = _1299;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1300 = this.TC6.localPosition.y + 1;
                        Vector3 _1301 = this.TC6.localPosition;
                        _1301.y = _1300;
                        this.TC6.localPosition = _1301;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1302 = this.TC7.localPosition.y + 1;
                        Vector3 _1303 = this.TC7.localPosition;
                        _1303.y = _1302;
                        this.TC7.localPosition = _1303;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1304 = this.TC8.localPosition.y + 1;
                        Vector3 _1305 = this.TC8.localPosition;
                        _1305.y = _1304;
                        this.TC8.localPosition = _1305;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1306 = this.TC9.localPosition.y + 1;
                        Vector3 _1307 = this.TC9.localPosition;
                        _1307.y = _1306;
                        this.TC9.localPosition = _1307;
                    }
                }
            }

            {
                float _1308 = 0.5f;
                Color _1309 = this.TC2r.material.color;
                _1309.a = _1308;
                this.TC2r.material.color = _1309;
            }
            this.TC2f = true;
            DamageCounter.TC2Amount = DamageCounter.TC2Amount + Amount;
            this.TC2Text.text = Mathf.RoundToInt(DamageCounter.TC2Amount).ToString();
        }
        if (Code == 3)
        {
            if (!this.TC3Up)
            {
                this.TC3Up = true;

                {
                    float _1310 = this.TC3.localPosition.y + 10;
                    Vector3 _1311 = this.TC3.localPosition;
                    _1311.y = _1310;
                    this.TC3.localPosition = _1311;
                }

                {
                    float _1312 = this.Title.localPosition.y + 1;
                    Vector3 _1313 = this.Title.localPosition;
                    _1313.y = _1312;
                    this.Title.localPosition = _1313;
                }
                if (this.TC0Up)
                {

                    {
                        float _1314 = this.TC0.localPosition.y + 1;
                        Vector3 _1315 = this.TC0.localPosition;
                        _1315.y = _1314;
                        this.TC0.localPosition = _1315;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1316 = this.TC2.localPosition.y + 1;
                        Vector3 _1317 = this.TC2.localPosition;
                        _1317.y = _1316;
                        this.TC2.localPosition = _1317;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1318 = this.TC4.localPosition.y + 1;
                        Vector3 _1319 = this.TC4.localPosition;
                        _1319.y = _1318;
                        this.TC4.localPosition = _1319;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1320 = this.TC5.localPosition.y + 1;
                        Vector3 _1321 = this.TC5.localPosition;
                        _1321.y = _1320;
                        this.TC5.localPosition = _1321;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1322 = this.TC6.localPosition.y + 1;
                        Vector3 _1323 = this.TC6.localPosition;
                        _1323.y = _1322;
                        this.TC6.localPosition = _1323;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1324 = this.TC7.localPosition.y + 1;
                        Vector3 _1325 = this.TC7.localPosition;
                        _1325.y = _1324;
                        this.TC7.localPosition = _1325;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1326 = this.TC8.localPosition.y + 1;
                        Vector3 _1327 = this.TC8.localPosition;
                        _1327.y = _1326;
                        this.TC8.localPosition = _1327;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1328 = this.TC9.localPosition.y + 1;
                        Vector3 _1329 = this.TC9.localPosition;
                        _1329.y = _1328;
                        this.TC9.localPosition = _1329;
                    }
                }
            }

            {
                float _1330 = 0.5f;
                Color _1331 = this.TC3r.material.color;
                _1331.a = _1330;
                this.TC3r.material.color = _1331;
            }
            this.TC3f = true;
            DamageCounter.TC3Amount = DamageCounter.TC3Amount + Amount;
            this.TC3Text.text = Mathf.RoundToInt(DamageCounter.TC3Amount).ToString();
        }
        if (Code == 4)
        {
            if (!this.TC4Up)
            {
                this.TC4Up = true;

                {
                    float _1332 = this.TC4.localPosition.y + 10;
                    Vector3 _1333 = this.TC4.localPosition;
                    _1333.y = _1332;
                    this.TC4.localPosition = _1333;
                }

                {
                    float _1334 = this.Title.localPosition.y + 1;
                    Vector3 _1335 = this.Title.localPosition;
                    _1335.y = _1334;
                    this.Title.localPosition = _1335;
                }
                if (this.TC0Up)
                {

                    {
                        float _1336 = this.TC0.localPosition.y + 1;
                        Vector3 _1337 = this.TC0.localPosition;
                        _1337.y = _1336;
                        this.TC0.localPosition = _1337;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1338 = this.TC2.localPosition.y + 1;
                        Vector3 _1339 = this.TC2.localPosition;
                        _1339.y = _1338;
                        this.TC2.localPosition = _1339;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1340 = this.TC3.localPosition.y + 1;
                        Vector3 _1341 = this.TC3.localPosition;
                        _1341.y = _1340;
                        this.TC3.localPosition = _1341;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1342 = this.TC5.localPosition.y + 1;
                        Vector3 _1343 = this.TC5.localPosition;
                        _1343.y = _1342;
                        this.TC5.localPosition = _1343;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1344 = this.TC6.localPosition.y + 1;
                        Vector3 _1345 = this.TC6.localPosition;
                        _1345.y = _1344;
                        this.TC6.localPosition = _1345;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1346 = this.TC7.localPosition.y + 1;
                        Vector3 _1347 = this.TC7.localPosition;
                        _1347.y = _1346;
                        this.TC7.localPosition = _1347;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1348 = this.TC8.localPosition.y + 1;
                        Vector3 _1349 = this.TC8.localPosition;
                        _1349.y = _1348;
                        this.TC8.localPosition = _1349;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1350 = this.TC9.localPosition.y + 1;
                        Vector3 _1351 = this.TC9.localPosition;
                        _1351.y = _1350;
                        this.TC9.localPosition = _1351;
                    }
                }
            }

            {
                float _1352 = 0.5f;
                Color _1353 = this.TC4r.material.color;
                _1353.a = _1352;
                this.TC4r.material.color = _1353;
            }
            this.TC4f = true;
            DamageCounter.TC4Amount = DamageCounter.TC4Amount + Amount;
            this.TC4Text.text = Mathf.RoundToInt(DamageCounter.TC4Amount).ToString();
        }
        if (Code == 5)
        {
            if (!this.TC5Up)
            {
                this.TC5Up = true;

                {
                    float _1354 = this.TC5.localPosition.y + 10;
                    Vector3 _1355 = this.TC5.localPosition;
                    _1355.y = _1354;
                    this.TC5.localPosition = _1355;
                }

                {
                    float _1356 = this.Title.localPosition.y + 1;
                    Vector3 _1357 = this.Title.localPosition;
                    _1357.y = _1356;
                    this.Title.localPosition = _1357;
                }
                if (this.TC0Up)
                {

                    {
                        float _1358 = this.TC0.localPosition.y + 1;
                        Vector3 _1359 = this.TC0.localPosition;
                        _1359.y = _1358;
                        this.TC0.localPosition = _1359;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1360 = this.TC2.localPosition.y + 1;
                        Vector3 _1361 = this.TC2.localPosition;
                        _1361.y = _1360;
                        this.TC2.localPosition = _1361;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1362 = this.TC3.localPosition.y + 1;
                        Vector3 _1363 = this.TC3.localPosition;
                        _1363.y = _1362;
                        this.TC3.localPosition = _1363;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1364 = this.TC4.localPosition.y + 1;
                        Vector3 _1365 = this.TC4.localPosition;
                        _1365.y = _1364;
                        this.TC4.localPosition = _1365;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1366 = this.TC6.localPosition.y + 1;
                        Vector3 _1367 = this.TC6.localPosition;
                        _1367.y = _1366;
                        this.TC6.localPosition = _1367;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1368 = this.TC7.localPosition.y + 1;
                        Vector3 _1369 = this.TC7.localPosition;
                        _1369.y = _1368;
                        this.TC7.localPosition = _1369;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1370 = this.TC8.localPosition.y + 1;
                        Vector3 _1371 = this.TC8.localPosition;
                        _1371.y = _1370;
                        this.TC8.localPosition = _1371;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1372 = this.TC9.localPosition.y + 1;
                        Vector3 _1373 = this.TC9.localPosition;
                        _1373.y = _1372;
                        this.TC9.localPosition = _1373;
                    }
                }
            }

            {
                float _1374 = 0.5f;
                Color _1375 = this.TC5r.material.color;
                _1375.a = _1374;
                this.TC5r.material.color = _1375;
            }
            this.TC5f = true;
            DamageCounter.TC5Amount = DamageCounter.TC5Amount + Amount;
            this.TC5Text.text = Mathf.RoundToInt(DamageCounter.TC5Amount).ToString();
        }
        if (Code == 6)
        {
            if (!this.TC6Up)
            {
                this.TC6Up = true;

                {
                    float _1376 = this.TC6.localPosition.y + 10;
                    Vector3 _1377 = this.TC6.localPosition;
                    _1377.y = _1376;
                    this.TC6.localPosition = _1377;
                }

                {
                    float _1378 = this.Title.localPosition.y + 1;
                    Vector3 _1379 = this.Title.localPosition;
                    _1379.y = _1378;
                    this.Title.localPosition = _1379;
                }
                if (this.TC0Up)
                {

                    {
                        float _1380 = this.TC0.localPosition.y + 1;
                        Vector3 _1381 = this.TC0.localPosition;
                        _1381.y = _1380;
                        this.TC0.localPosition = _1381;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1382 = this.TC2.localPosition.y + 1;
                        Vector3 _1383 = this.TC2.localPosition;
                        _1383.y = _1382;
                        this.TC2.localPosition = _1383;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1384 = this.TC3.localPosition.y + 1;
                        Vector3 _1385 = this.TC3.localPosition;
                        _1385.y = _1384;
                        this.TC3.localPosition = _1385;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1386 = this.TC4.localPosition.y + 1;
                        Vector3 _1387 = this.TC4.localPosition;
                        _1387.y = _1386;
                        this.TC4.localPosition = _1387;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1388 = this.TC5.localPosition.y + 1;
                        Vector3 _1389 = this.TC5.localPosition;
                        _1389.y = _1388;
                        this.TC5.localPosition = _1389;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1390 = this.TC7.localPosition.y + 1;
                        Vector3 _1391 = this.TC7.localPosition;
                        _1391.y = _1390;
                        this.TC7.localPosition = _1391;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1392 = this.TC8.localPosition.y + 1;
                        Vector3 _1393 = this.TC8.localPosition;
                        _1393.y = _1392;
                        this.TC8.localPosition = _1393;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1394 = this.TC9.localPosition.y + 1;
                        Vector3 _1395 = this.TC9.localPosition;
                        _1395.y = _1394;
                        this.TC9.localPosition = _1395;
                    }
                }
            }

            {
                float _1396 = 0.5f;
                Color _1397 = this.TC6r.material.color;
                _1397.a = _1396;
                this.TC6r.material.color = _1397;
            }
            this.TC6f = true;
            DamageCounter.TC6Amount = DamageCounter.TC6Amount + Amount;
            this.TC6Text.text = Mathf.RoundToInt(DamageCounter.TC6Amount).ToString();
        }
        if (Code == 7)
        {
            if (!this.TC7Up)
            {
                this.TC7Up = true;

                {
                    float _1398 = this.TC7.localPosition.y + 10;
                    Vector3 _1399 = this.TC7.localPosition;
                    _1399.y = _1398;
                    this.TC7.localPosition = _1399;
                }

                {
                    float _1400 = this.Title.localPosition.y + 1;
                    Vector3 _1401 = this.Title.localPosition;
                    _1401.y = _1400;
                    this.Title.localPosition = _1401;
                }
                if (this.TC0Up)
                {

                    {
                        float _1402 = this.TC0.localPosition.y + 1;
                        Vector3 _1403 = this.TC0.localPosition;
                        _1403.y = _1402;
                        this.TC0.localPosition = _1403;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1404 = this.TC2.localPosition.y + 1;
                        Vector3 _1405 = this.TC2.localPosition;
                        _1405.y = _1404;
                        this.TC2.localPosition = _1405;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1406 = this.TC3.localPosition.y + 1;
                        Vector3 _1407 = this.TC3.localPosition;
                        _1407.y = _1406;
                        this.TC3.localPosition = _1407;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1408 = this.TC4.localPosition.y + 1;
                        Vector3 _1409 = this.TC4.localPosition;
                        _1409.y = _1408;
                        this.TC4.localPosition = _1409;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1410 = this.TC5.localPosition.y + 1;
                        Vector3 _1411 = this.TC5.localPosition;
                        _1411.y = _1410;
                        this.TC5.localPosition = _1411;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1412 = this.TC6.localPosition.y + 1;
                        Vector3 _1413 = this.TC6.localPosition;
                        _1413.y = _1412;
                        this.TC6.localPosition = _1413;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1414 = this.TC8.localPosition.y + 1;
                        Vector3 _1415 = this.TC8.localPosition;
                        _1415.y = _1414;
                        this.TC8.localPosition = _1415;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1416 = this.TC9.localPosition.y + 1;
                        Vector3 _1417 = this.TC9.localPosition;
                        _1417.y = _1416;
                        this.TC9.localPosition = _1417;
                    }
                }
            }

            {
                float _1418 = 0.5f;
                Color _1419 = this.TC7r.material.color;
                _1419.a = _1418;
                this.TC7r.material.color = _1419;
            }
            this.TC7f = true;
            DamageCounter.TC7Amount = DamageCounter.TC7Amount + Amount;
            this.TC7Text.text = Mathf.RoundToInt(DamageCounter.TC7Amount).ToString();
        }
        if (Code == 8)
        {
            if (!this.TC8Up)
            {
                this.TC8Up = true;

                {
                    float _1420 = this.TC8.localPosition.y + 10;
                    Vector3 _1421 = this.TC8.localPosition;
                    _1421.y = _1420;
                    this.TC8.localPosition = _1421;
                }

                {
                    float _1422 = this.Title.localPosition.y + 1;
                    Vector3 _1423 = this.Title.localPosition;
                    _1423.y = _1422;
                    this.Title.localPosition = _1423;
                }
                if (this.TC0Up)
                {

                    {
                        float _1424 = this.TC0.localPosition.y + 1;
                        Vector3 _1425 = this.TC0.localPosition;
                        _1425.y = _1424;
                        this.TC0.localPosition = _1425;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1426 = this.TC2.localPosition.y + 1;
                        Vector3 _1427 = this.TC2.localPosition;
                        _1427.y = _1426;
                        this.TC2.localPosition = _1427;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1428 = this.TC3.localPosition.y + 1;
                        Vector3 _1429 = this.TC3.localPosition;
                        _1429.y = _1428;
                        this.TC3.localPosition = _1429;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1430 = this.TC4.localPosition.y + 1;
                        Vector3 _1431 = this.TC4.localPosition;
                        _1431.y = _1430;
                        this.TC4.localPosition = _1431;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1432 = this.TC5.localPosition.y + 1;
                        Vector3 _1433 = this.TC5.localPosition;
                        _1433.y = _1432;
                        this.TC5.localPosition = _1433;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1434 = this.TC6.localPosition.y + 1;
                        Vector3 _1435 = this.TC6.localPosition;
                        _1435.y = _1434;
                        this.TC6.localPosition = _1435;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1436 = this.TC7.localPosition.y + 1;
                        Vector3 _1437 = this.TC7.localPosition;
                        _1437.y = _1436;
                        this.TC7.localPosition = _1437;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1438 = this.TC9.localPosition.y + 1;
                        Vector3 _1439 = this.TC9.localPosition;
                        _1439.y = _1438;
                        this.TC9.localPosition = _1439;
                    }
                }
            }

            {
                float _1440 = 0.5f;
                Color _1441 = this.TC8r.material.color;
                _1441.a = _1440;
                this.TC8r.material.color = _1441;
            }
            this.TC8f = true;
            DamageCounter.TC8Amount = DamageCounter.TC8Amount + Amount;
            this.TC8Text.text = Mathf.RoundToInt(DamageCounter.TC8Amount).ToString();
        }
        if (Code == 9)
        {
            if (!this.TC9Up)
            {
                this.TC9Up = true;

                {
                    float _1442 = this.TC9.localPosition.y + 10;
                    Vector3 _1443 = this.TC9.localPosition;
                    _1443.y = _1442;
                    this.TC9.localPosition = _1443;
                }

                {
                    float _1444 = this.Title.localPosition.y + 1;
                    Vector3 _1445 = this.Title.localPosition;
                    _1445.y = _1444;
                    this.Title.localPosition = _1445;
                }
                if (this.TC0Up)
                {

                    {
                        float _1446 = this.TC0.localPosition.y + 1;
                        Vector3 _1447 = this.TC0.localPosition;
                        _1447.y = _1446;
                        this.TC0.localPosition = _1447;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1448 = this.TC2.localPosition.y + 1;
                        Vector3 _1449 = this.TC2.localPosition;
                        _1449.y = _1448;
                        this.TC2.localPosition = _1449;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1450 = this.TC3.localPosition.y + 1;
                        Vector3 _1451 = this.TC3.localPosition;
                        _1451.y = _1450;
                        this.TC3.localPosition = _1451;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1452 = this.TC4.localPosition.y + 1;
                        Vector3 _1453 = this.TC4.localPosition;
                        _1453.y = _1452;
                        this.TC4.localPosition = _1453;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1454 = this.TC5.localPosition.y + 1;
                        Vector3 _1455 = this.TC5.localPosition;
                        _1455.y = _1454;
                        this.TC5.localPosition = _1455;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1456 = this.TC6.localPosition.y + 1;
                        Vector3 _1457 = this.TC6.localPosition;
                        _1457.y = _1456;
                        this.TC6.localPosition = _1457;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1458 = this.TC7.localPosition.y + 1;
                        Vector3 _1459 = this.TC7.localPosition;
                        _1459.y = _1458;
                        this.TC7.localPosition = _1459;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1460 = this.TC8.localPosition.y + 1;
                        Vector3 _1461 = this.TC8.localPosition;
                        _1461.y = _1460;
                        this.TC8.localPosition = _1461;
                    }
                }
            }

            {
                float _1462 = 0.5f;
                Color _1463 = this.TC9r.material.color;
                _1463.a = _1462;
                this.TC9r.material.color = _1463;
            }
            this.TC9f = true;
            DamageCounter.TC9Amount = DamageCounter.TC9Amount + Amount;
            this.TC9Text.text = Mathf.RoundToInt(DamageCounter.TC9Amount).ToString();
        }
    }

    public virtual void UpdateDamage(int Code)
    {
        if (!this.Up)
        {
            this.Up = true;

            {
                float _1464 = this.Title.localPosition.y + 10;
                Vector3 _1465 = this.Title.localPosition;
                _1465.y = _1464;
                this.Title.localPosition = _1465;
            }
        }
        if (Code == 0)
        {
            if (!this.TC0Up)
            {
                this.TC0Up = true;

                {
                    float _1466 = this.TC0.localPosition.y + 10;
                    Vector3 _1467 = this.TC0.localPosition;
                    _1467.y = _1466;
                    this.TC0.localPosition = _1467;
                }

                {
                    float _1468 = this.Title.localPosition.y + 1;
                    Vector3 _1469 = this.Title.localPosition;
                    _1469.y = _1468;
                    this.Title.localPosition = _1469;
                }
                if (this.TC2Up)
                {

                    {
                        float _1470 = this.TC2.localPosition.y + 1;
                        Vector3 _1471 = this.TC2.localPosition;
                        _1471.y = _1470;
                        this.TC2.localPosition = _1471;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1472 = this.TC3.localPosition.y + 1;
                        Vector3 _1473 = this.TC3.localPosition;
                        _1473.y = _1472;
                        this.TC3.localPosition = _1473;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1474 = this.TC4.localPosition.y + 1;
                        Vector3 _1475 = this.TC4.localPosition;
                        _1475.y = _1474;
                        this.TC4.localPosition = _1475;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1476 = this.TC5.localPosition.y + 1;
                        Vector3 _1477 = this.TC5.localPosition;
                        _1477.y = _1476;
                        this.TC5.localPosition = _1477;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1478 = this.TC6.localPosition.y + 1;
                        Vector3 _1479 = this.TC6.localPosition;
                        _1479.y = _1478;
                        this.TC6.localPosition = _1479;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1480 = this.TC7.localPosition.y + 1;
                        Vector3 _1481 = this.TC7.localPosition;
                        _1481.y = _1480;
                        this.TC7.localPosition = _1481;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1482 = this.TC8.localPosition.y + 1;
                        Vector3 _1483 = this.TC8.localPosition;
                        _1483.y = _1482;
                        this.TC8.localPosition = _1483;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1484 = this.TC9.localPosition.y + 1;
                        Vector3 _1485 = this.TC9.localPosition;
                        _1485.y = _1484;
                        this.TC9.localPosition = _1485;
                    }
                }
            }

            {
                float _1486 = 0.5f;
                Color _1487 = this.TC0r.material.color;
                _1487.a = _1486;
                this.TC0r.material.color = _1487;
            }
            this.TC0f = true;
            this.TC0Text.text = Mathf.RoundToInt(DamageCounter.TC0Amount).ToString();
        }
        if (Code == 2)
        {
            if (!this.TC2Up)
            {
                this.TC2Up = true;

                {
                    float _1488 = this.TC2.localPosition.y + 10;
                    Vector3 _1489 = this.TC2.localPosition;
                    _1489.y = _1488;
                    this.TC2.localPosition = _1489;
                }

                {
                    float _1490 = this.Title.localPosition.y + 1;
                    Vector3 _1491 = this.Title.localPosition;
                    _1491.y = _1490;
                    this.Title.localPosition = _1491;
                }
                if (this.TC0Up)
                {

                    {
                        float _1492 = this.TC0.localPosition.y + 1;
                        Vector3 _1493 = this.TC0.localPosition;
                        _1493.y = _1492;
                        this.TC0.localPosition = _1493;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1494 = this.TC3.localPosition.y + 1;
                        Vector3 _1495 = this.TC3.localPosition;
                        _1495.y = _1494;
                        this.TC3.localPosition = _1495;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1496 = this.TC4.localPosition.y + 1;
                        Vector3 _1497 = this.TC4.localPosition;
                        _1497.y = _1496;
                        this.TC4.localPosition = _1497;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1498 = this.TC5.localPosition.y + 1;
                        Vector3 _1499 = this.TC5.localPosition;
                        _1499.y = _1498;
                        this.TC5.localPosition = _1499;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1500 = this.TC6.localPosition.y + 1;
                        Vector3 _1501 = this.TC6.localPosition;
                        _1501.y = _1500;
                        this.TC6.localPosition = _1501;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1502 = this.TC7.localPosition.y + 1;
                        Vector3 _1503 = this.TC7.localPosition;
                        _1503.y = _1502;
                        this.TC7.localPosition = _1503;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1504 = this.TC8.localPosition.y + 1;
                        Vector3 _1505 = this.TC8.localPosition;
                        _1505.y = _1504;
                        this.TC8.localPosition = _1505;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1506 = this.TC9.localPosition.y + 1;
                        Vector3 _1507 = this.TC9.localPosition;
                        _1507.y = _1506;
                        this.TC9.localPosition = _1507;
                    }
                }
            }

            {
                float _1508 = 0.5f;
                Color _1509 = this.TC2r.material.color;
                _1509.a = _1508;
                this.TC2r.material.color = _1509;
            }
            this.TC2f = true;
            this.TC2Text.text = Mathf.RoundToInt(DamageCounter.TC2Amount).ToString();
        }
        if (Code == 3)
        {
            if (!this.TC3Up)
            {
                this.TC3Up = true;

                {
                    float _1510 = this.TC3.localPosition.y + 10;
                    Vector3 _1511 = this.TC3.localPosition;
                    _1511.y = _1510;
                    this.TC3.localPosition = _1511;
                }

                {
                    float _1512 = this.Title.localPosition.y + 1;
                    Vector3 _1513 = this.Title.localPosition;
                    _1513.y = _1512;
                    this.Title.localPosition = _1513;
                }
                if (this.TC0Up)
                {

                    {
                        float _1514 = this.TC0.localPosition.y + 1;
                        Vector3 _1515 = this.TC0.localPosition;
                        _1515.y = _1514;
                        this.TC0.localPosition = _1515;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1516 = this.TC2.localPosition.y + 1;
                        Vector3 _1517 = this.TC2.localPosition;
                        _1517.y = _1516;
                        this.TC2.localPosition = _1517;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1518 = this.TC4.localPosition.y + 1;
                        Vector3 _1519 = this.TC4.localPosition;
                        _1519.y = _1518;
                        this.TC4.localPosition = _1519;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1520 = this.TC5.localPosition.y + 1;
                        Vector3 _1521 = this.TC5.localPosition;
                        _1521.y = _1520;
                        this.TC5.localPosition = _1521;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1522 = this.TC6.localPosition.y + 1;
                        Vector3 _1523 = this.TC6.localPosition;
                        _1523.y = _1522;
                        this.TC6.localPosition = _1523;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1524 = this.TC7.localPosition.y + 1;
                        Vector3 _1525 = this.TC7.localPosition;
                        _1525.y = _1524;
                        this.TC7.localPosition = _1525;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1526 = this.TC8.localPosition.y + 1;
                        Vector3 _1527 = this.TC8.localPosition;
                        _1527.y = _1526;
                        this.TC8.localPosition = _1527;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1528 = this.TC9.localPosition.y + 1;
                        Vector3 _1529 = this.TC9.localPosition;
                        _1529.y = _1528;
                        this.TC9.localPosition = _1529;
                    }
                }
            }

            {
                float _1530 = 0.5f;
                Color _1531 = this.TC3r.material.color;
                _1531.a = _1530;
                this.TC3r.material.color = _1531;
            }
            this.TC3f = true;
            this.TC3Text.text = Mathf.RoundToInt(DamageCounter.TC3Amount).ToString();
        }
        if (Code == 4)
        {
            if (!this.TC4Up)
            {
                this.TC4Up = true;

                {
                    float _1532 = this.TC4.localPosition.y + 10;
                    Vector3 _1533 = this.TC4.localPosition;
                    _1533.y = _1532;
                    this.TC4.localPosition = _1533;
                }

                {
                    float _1534 = this.Title.localPosition.y + 1;
                    Vector3 _1535 = this.Title.localPosition;
                    _1535.y = _1534;
                    this.Title.localPosition = _1535;
                }
                if (this.TC0Up)
                {

                    {
                        float _1536 = this.TC0.localPosition.y + 1;
                        Vector3 _1537 = this.TC0.localPosition;
                        _1537.y = _1536;
                        this.TC0.localPosition = _1537;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1538 = this.TC2.localPosition.y + 1;
                        Vector3 _1539 = this.TC2.localPosition;
                        _1539.y = _1538;
                        this.TC2.localPosition = _1539;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1540 = this.TC3.localPosition.y + 1;
                        Vector3 _1541 = this.TC3.localPosition;
                        _1541.y = _1540;
                        this.TC3.localPosition = _1541;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1542 = this.TC5.localPosition.y + 1;
                        Vector3 _1543 = this.TC5.localPosition;
                        _1543.y = _1542;
                        this.TC5.localPosition = _1543;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1544 = this.TC6.localPosition.y + 1;
                        Vector3 _1545 = this.TC6.localPosition;
                        _1545.y = _1544;
                        this.TC6.localPosition = _1545;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1546 = this.TC7.localPosition.y + 1;
                        Vector3 _1547 = this.TC7.localPosition;
                        _1547.y = _1546;
                        this.TC7.localPosition = _1547;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1548 = this.TC8.localPosition.y + 1;
                        Vector3 _1549 = this.TC8.localPosition;
                        _1549.y = _1548;
                        this.TC8.localPosition = _1549;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1550 = this.TC9.localPosition.y + 1;
                        Vector3 _1551 = this.TC9.localPosition;
                        _1551.y = _1550;
                        this.TC9.localPosition = _1551;
                    }
                }
            }

            {
                float _1552 = 0.5f;
                Color _1553 = this.TC4r.material.color;
                _1553.a = _1552;
                this.TC4r.material.color = _1553;
            }
            this.TC4f = true;
            this.TC4Text.text = Mathf.RoundToInt(DamageCounter.TC4Amount).ToString();
        }
        if (Code == 5)
        {
            if (!this.TC5Up)
            {
                this.TC5Up = true;

                {
                    float _1554 = this.TC5.localPosition.y + 10;
                    Vector3 _1555 = this.TC5.localPosition;
                    _1555.y = _1554;
                    this.TC5.localPosition = _1555;
                }

                {
                    float _1556 = this.Title.localPosition.y + 1;
                    Vector3 _1557 = this.Title.localPosition;
                    _1557.y = _1556;
                    this.Title.localPosition = _1557;
                }
                if (this.TC0Up)
                {

                    {
                        float _1558 = this.TC0.localPosition.y + 1;
                        Vector3 _1559 = this.TC0.localPosition;
                        _1559.y = _1558;
                        this.TC0.localPosition = _1559;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1560 = this.TC2.localPosition.y + 1;
                        Vector3 _1561 = this.TC2.localPosition;
                        _1561.y = _1560;
                        this.TC2.localPosition = _1561;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1562 = this.TC3.localPosition.y + 1;
                        Vector3 _1563 = this.TC3.localPosition;
                        _1563.y = _1562;
                        this.TC3.localPosition = _1563;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1564 = this.TC4.localPosition.y + 1;
                        Vector3 _1565 = this.TC4.localPosition;
                        _1565.y = _1564;
                        this.TC4.localPosition = _1565;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1566 = this.TC6.localPosition.y + 1;
                        Vector3 _1567 = this.TC6.localPosition;
                        _1567.y = _1566;
                        this.TC6.localPosition = _1567;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1568 = this.TC7.localPosition.y + 1;
                        Vector3 _1569 = this.TC7.localPosition;
                        _1569.y = _1568;
                        this.TC7.localPosition = _1569;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1570 = this.TC8.localPosition.y + 1;
                        Vector3 _1571 = this.TC8.localPosition;
                        _1571.y = _1570;
                        this.TC8.localPosition = _1571;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1572 = this.TC9.localPosition.y + 1;
                        Vector3 _1573 = this.TC9.localPosition;
                        _1573.y = _1572;
                        this.TC9.localPosition = _1573;
                    }
                }
            }

            {
                float _1574 = 0.5f;
                Color _1575 = this.TC5r.material.color;
                _1575.a = _1574;
                this.TC5r.material.color = _1575;
            }
            this.TC5f = true;
            this.TC5Text.text = Mathf.RoundToInt(DamageCounter.TC5Amount).ToString();
        }
        if (Code == 6)
        {
            if (!this.TC6Up)
            {
                this.TC6Up = true;

                {
                    float _1576 = this.TC6.localPosition.y + 10;
                    Vector3 _1577 = this.TC6.localPosition;
                    _1577.y = _1576;
                    this.TC6.localPosition = _1577;
                }

                {
                    float _1578 = this.Title.localPosition.y + 1;
                    Vector3 _1579 = this.Title.localPosition;
                    _1579.y = _1578;
                    this.Title.localPosition = _1579;
                }
                if (this.TC0Up)
                {

                    {
                        float _1580 = this.TC0.localPosition.y + 1;
                        Vector3 _1581 = this.TC0.localPosition;
                        _1581.y = _1580;
                        this.TC0.localPosition = _1581;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1582 = this.TC2.localPosition.y + 1;
                        Vector3 _1583 = this.TC2.localPosition;
                        _1583.y = _1582;
                        this.TC2.localPosition = _1583;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1584 = this.TC3.localPosition.y + 1;
                        Vector3 _1585 = this.TC3.localPosition;
                        _1585.y = _1584;
                        this.TC3.localPosition = _1585;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1586 = this.TC4.localPosition.y + 1;
                        Vector3 _1587 = this.TC4.localPosition;
                        _1587.y = _1586;
                        this.TC4.localPosition = _1587;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1588 = this.TC5.localPosition.y + 1;
                        Vector3 _1589 = this.TC5.localPosition;
                        _1589.y = _1588;
                        this.TC5.localPosition = _1589;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1590 = this.TC7.localPosition.y + 1;
                        Vector3 _1591 = this.TC7.localPosition;
                        _1591.y = _1590;
                        this.TC7.localPosition = _1591;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1592 = this.TC8.localPosition.y + 1;
                        Vector3 _1593 = this.TC8.localPosition;
                        _1593.y = _1592;
                        this.TC8.localPosition = _1593;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1594 = this.TC9.localPosition.y + 1;
                        Vector3 _1595 = this.TC9.localPosition;
                        _1595.y = _1594;
                        this.TC9.localPosition = _1595;
                    }
                }
            }

            {
                float _1596 = 0.5f;
                Color _1597 = this.TC6r.material.color;
                _1597.a = _1596;
                this.TC6r.material.color = _1597;
            }
            this.TC6f = true;
            this.TC6Text.text = Mathf.RoundToInt(DamageCounter.TC6Amount).ToString();
        }
        if (Code == 7)
        {
            if (!this.TC7Up)
            {
                this.TC7Up = true;

                {
                    float _1598 = this.TC7.localPosition.y + 10;
                    Vector3 _1599 = this.TC7.localPosition;
                    _1599.y = _1598;
                    this.TC7.localPosition = _1599;
                }

                {
                    float _1600 = this.Title.localPosition.y + 1;
                    Vector3 _1601 = this.Title.localPosition;
                    _1601.y = _1600;
                    this.Title.localPosition = _1601;
                }
                if (this.TC0Up)
                {

                    {
                        float _1602 = this.TC0.localPosition.y + 1;
                        Vector3 _1603 = this.TC0.localPosition;
                        _1603.y = _1602;
                        this.TC0.localPosition = _1603;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1604 = this.TC2.localPosition.y + 1;
                        Vector3 _1605 = this.TC2.localPosition;
                        _1605.y = _1604;
                        this.TC2.localPosition = _1605;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1606 = this.TC3.localPosition.y + 1;
                        Vector3 _1607 = this.TC3.localPosition;
                        _1607.y = _1606;
                        this.TC3.localPosition = _1607;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1608 = this.TC4.localPosition.y + 1;
                        Vector3 _1609 = this.TC4.localPosition;
                        _1609.y = _1608;
                        this.TC4.localPosition = _1609;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1610 = this.TC5.localPosition.y + 1;
                        Vector3 _1611 = this.TC5.localPosition;
                        _1611.y = _1610;
                        this.TC5.localPosition = _1611;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1612 = this.TC6.localPosition.y + 1;
                        Vector3 _1613 = this.TC6.localPosition;
                        _1613.y = _1612;
                        this.TC6.localPosition = _1613;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1614 = this.TC8.localPosition.y + 1;
                        Vector3 _1615 = this.TC8.localPosition;
                        _1615.y = _1614;
                        this.TC8.localPosition = _1615;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1616 = this.TC9.localPosition.y + 1;
                        Vector3 _1617 = this.TC9.localPosition;
                        _1617.y = _1616;
                        this.TC9.localPosition = _1617;
                    }
                }
            }

            {
                float _1618 = 0.5f;
                Color _1619 = this.TC7r.material.color;
                _1619.a = _1618;
                this.TC7r.material.color = _1619;
            }
            this.TC7f = true;
            this.TC7Text.text = Mathf.RoundToInt(DamageCounter.TC7Amount).ToString();
        }
        if (Code == 8)
        {
            if (!this.TC8Up)
            {
                this.TC8Up = true;

                {
                    float _1620 = this.TC8.localPosition.y + 10;
                    Vector3 _1621 = this.TC8.localPosition;
                    _1621.y = _1620;
                    this.TC8.localPosition = _1621;
                }

                {
                    float _1622 = this.Title.localPosition.y + 1;
                    Vector3 _1623 = this.Title.localPosition;
                    _1623.y = _1622;
                    this.Title.localPosition = _1623;
                }
                if (this.TC0Up)
                {

                    {
                        float _1624 = this.TC0.localPosition.y + 1;
                        Vector3 _1625 = this.TC0.localPosition;
                        _1625.y = _1624;
                        this.TC0.localPosition = _1625;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1626 = this.TC2.localPosition.y + 1;
                        Vector3 _1627 = this.TC2.localPosition;
                        _1627.y = _1626;
                        this.TC2.localPosition = _1627;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1628 = this.TC3.localPosition.y + 1;
                        Vector3 _1629 = this.TC3.localPosition;
                        _1629.y = _1628;
                        this.TC3.localPosition = _1629;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1630 = this.TC4.localPosition.y + 1;
                        Vector3 _1631 = this.TC4.localPosition;
                        _1631.y = _1630;
                        this.TC4.localPosition = _1631;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1632 = this.TC5.localPosition.y + 1;
                        Vector3 _1633 = this.TC5.localPosition;
                        _1633.y = _1632;
                        this.TC5.localPosition = _1633;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1634 = this.TC6.localPosition.y + 1;
                        Vector3 _1635 = this.TC6.localPosition;
                        _1635.y = _1634;
                        this.TC6.localPosition = _1635;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1636 = this.TC7.localPosition.y + 1;
                        Vector3 _1637 = this.TC7.localPosition;
                        _1637.y = _1636;
                        this.TC7.localPosition = _1637;
                    }
                }
                if (this.TC9Up)
                {

                    {
                        float _1638 = this.TC9.localPosition.y + 1;
                        Vector3 _1639 = this.TC9.localPosition;
                        _1639.y = _1638;
                        this.TC9.localPosition = _1639;
                    }
                }
            }

            {
                float _1640 = 0.5f;
                Color _1641 = this.TC8r.material.color;
                _1641.a = _1640;
                this.TC8r.material.color = _1641;
            }
            this.TC8f = true;
            this.TC8Text.text = Mathf.RoundToInt(DamageCounter.TC8Amount).ToString();
        }
        if (Code == 9)
        {
            if (!this.TC9Up)
            {
                this.TC9Up = true;

                {
                    float _1642 = this.TC9.localPosition.y + 10;
                    Vector3 _1643 = this.TC9.localPosition;
                    _1643.y = _1642;
                    this.TC9.localPosition = _1643;
                }

                {
                    float _1644 = this.Title.localPosition.y + 1;
                    Vector3 _1645 = this.Title.localPosition;
                    _1645.y = _1644;
                    this.Title.localPosition = _1645;
                }
                if (this.TC0Up)
                {

                    {
                        float _1646 = this.TC0.localPosition.y + 1;
                        Vector3 _1647 = this.TC0.localPosition;
                        _1647.y = _1646;
                        this.TC0.localPosition = _1647;
                    }
                }
                if (this.TC2Up)
                {

                    {
                        float _1648 = this.TC2.localPosition.y + 1;
                        Vector3 _1649 = this.TC2.localPosition;
                        _1649.y = _1648;
                        this.TC2.localPosition = _1649;
                    }
                }
                if (this.TC3Up)
                {

                    {
                        float _1650 = this.TC3.localPosition.y + 1;
                        Vector3 _1651 = this.TC3.localPosition;
                        _1651.y = _1650;
                        this.TC3.localPosition = _1651;
                    }
                }
                if (this.TC4Up)
                {

                    {
                        float _1652 = this.TC4.localPosition.y + 1;
                        Vector3 _1653 = this.TC4.localPosition;
                        _1653.y = _1652;
                        this.TC4.localPosition = _1653;
                    }
                }
                if (this.TC5Up)
                {

                    {
                        float _1654 = this.TC5.localPosition.y + 1;
                        Vector3 _1655 = this.TC5.localPosition;
                        _1655.y = _1654;
                        this.TC5.localPosition = _1655;
                    }
                }
                if (this.TC6Up)
                {

                    {
                        float _1656 = this.TC6.localPosition.y + 1;
                        Vector3 _1657 = this.TC6.localPosition;
                        _1657.y = _1656;
                        this.TC6.localPosition = _1657;
                    }
                }
                if (this.TC7Up)
                {

                    {
                        float _1658 = this.TC7.localPosition.y + 1;
                        Vector3 _1659 = this.TC7.localPosition;
                        _1659.y = _1658;
                        this.TC7.localPosition = _1659;
                    }
                }
                if (this.TC8Up)
                {

                    {
                        float _1660 = this.TC8.localPosition.y + 1;
                        Vector3 _1661 = this.TC8.localPosition;
                        _1661.y = _1660;
                        this.TC8.localPosition = _1661;
                    }
                }
            }

            {
                float _1662 = 0.5f;
                Color _1663 = this.TC9r.material.color;
                _1663.a = _1662;
                this.TC9r.material.color = _1663;
            }
            this.TC9f = true;
            this.TC9Text.text = Mathf.RoundToInt(DamageCounter.TC9Amount).ToString();
        }
    }

}