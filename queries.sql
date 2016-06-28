select b.Username, Count(*)
from bettings b
	inner join matches m on m.Id = b.MatchId
where m.DateTime > '2016-06-25'
group by b.UserName

select * from bettings where username = 'haspie'
order by MatchId desc

select * from matches where id = 2191

begin tran
update bettings
set homescore = 0, awayscore = 1
where id = 4215
commit tran