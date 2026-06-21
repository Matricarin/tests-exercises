select UserId 
	from UserLogs 
	where Action = 'Click' and CreatedAt >= NOW() - interval '30 minutes'
	group by UserId
	having count(*) > 5;

CREATE INDEX idx_user_logs_action_created_user
    ON UserLogs (Action, CreatedAt, UserId);
