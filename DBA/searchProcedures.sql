select object_name(m.object_id) as object_name, m.definition, ob.*
from sys.sql_modules m
join sys.objects ob on ob.object_id = m.object_id
where definition like '%dane%'