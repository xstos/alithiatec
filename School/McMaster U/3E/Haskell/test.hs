main=print(fact 20)

fact :: Integer->Integer
fact n=if n==0 then 1 else n*fact(n-1)

vectorop::(Num a)=> (a->a->a)->[a]->[a]->[a]
vectorop f [] []=[]
vectorop f (x:xs) (y:ys)=(f x y):(vectorop f xs ys)

maxList (a:x) 
  | maxList x > a	= maxList x
  | otherwise		= a

