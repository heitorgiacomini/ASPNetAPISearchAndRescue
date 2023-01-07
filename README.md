Em-Progresso


Haversine formula x Vincenty

 great circle routes 
 
 criar circulo

	ALTER TABLE "Business"."AppOperation"
ADD COLUMN circle_column circle;

inserir  INSERT INTO "Business"."AppOperation" (circle_column)
VALUES ST_MakeCircle(ST_MakePoint(0, 0), 10000);

verificar se  ponto pertence a circulo
SELECT ST_Contains(ST_MakeCircle(ST_MakePoint(0, 0), 1.5), ST_MakePoint(1, 1)) AS contains;


