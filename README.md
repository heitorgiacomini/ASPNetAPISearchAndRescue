Em-Progresso


Haversine formula x Vincenty

 great circle routes 
 
 criar circulo
 SELECT ST_AsText(ST_MakeCircle(ST_MakePoint(0, 0), 1.5)) AS circle;

verificar se  ponto pertence a circulo
SELECT ST_Contains(ST_MakeCircle(ST_MakePoint(0, 0), 1.5), ST_MakePoint(1, 1)) AS contains;
