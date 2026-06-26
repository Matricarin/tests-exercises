create view task004 as select * from Orders where Status = 'Shipped' order by CreatedAt desc limit 10;

select * from task004;

explain analyse select * from task004;

--Limit  (cost=14584.62..14585.78 rows=10 width=23) (actual time=30.705..34.802 rows=10.00 loops=1)
--  Buffers: shared hit=6952
--  ->  Gather Merge  (cost=14584.62..33964.52 rows=166399 width=23) (actual time=30.702..34.797 rows=10.00 loops=1)
--        Workers Planned: 2
--        Workers Launched: 2
--        Buffers: shared hit=6952
--        ->  Sort  (cost=13584.59..13757.93 rows=69333 width=23) (actual time=27.423..27.424 rows=7.33 loops=3)
--              Sort Key: orders.createdat DESC
--              Sort Method: top-N heapsort  Memory: 26kB
--              Buffers: shared hit=6952
--              Worker 0:  Sort Method: top-N heapsort  Memory: 26kB
--              Worker 1:  Sort Method: top-N heapsort  Memory: 26kB
--              ->  Parallel Seq Scan on orders  (cost=0.00..12086.33 rows=69333 width=23) (actual time=0.022..23.062 rows=55518.67 loops=3)
--                    Filter: ((status)::text = 'Shipped'::text)
--                    Rows Removed by Filter: 277815
--                    Buffers: shared hit=6878
--Planning Time: 0.089 ms
--Execution Time: 34.833 ms

create index created_at_on_order_idx on Orders(CreatedAt);

--Limit  (cost=0.42..3.79 rows=10 width=23) (actual time=0.070..0.124 rows=10.00 loops=1)
--  Buffers: shared hit=60 read=3
--  ->  Index Scan Backward using created_at_on_order_idx on orders  (cost=0.42..55991.98 rows=166400 width=23) (actual time=0.069..0.122 rows=10.00 loops=1)
--        Filter: ((status)::text = 'Shipped'::text)
--        Rows Removed by Filter: 50
--        Index Searches: 1
--        Buffers: shared hit=60 read=3
--Planning:
--  Buffers: shared hit=15 read=1
--Planning Time: 0.295 ms
--Execution Time: 0.135 ms
