DECLARE 
  @Somedate DATETIME2(3) = '1991-05-05 08:00:07',
  @Somestri NVARCHAR(30)= '1996-05-05 08:00:07',
  @Someoldate DATETIME2(3) = '1991-05-05 08:00:07',
  @MyText NVARCHAR(33) = '120000',
  @Myweight NVARCHAR(12) ='170.34';

  SELECT
   CAST(@Somedate AS NVARCHAR(30)) AS Datetonvarchar,
   CAST(@Somestri AS DATETIME2(3)) AS dateasnumber,
   CAST(@MyText  AS INT) AS mynumbera,
   CAST(@Myweight AS FLOAT) AS myweightinlbs,
   CONVERT(NVARCHAR(33), @Somedate, 0) AS datedefault,
   CONVERT(NVARCHAR(44), @Somedate, 1) AS USMonthDayyy,
   CONVERT(NVARCHAR(33), @Someoldate, 101) AS USMonthDayYear,
   CONVERT(NVARCHAR(33), @Someoldate, 120) AS ODBC;



