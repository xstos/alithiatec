main=print(20)

concat2::[[a]]->[a]
concat2=foldr (++) []

scanl2::(a->a->a)->a->[a]->[a]
scanl2=scanl

strip::[Integer]->[Integer]
strip (x:xs)=if x==1 then x:xs else strip(xs)

sentence::[Char]->[Char]
sentence (x:xs)=if ((x==' ')==False) then x:(sentence) xs else []

sp::[Double]->[Double]->[Double]
sp [] []=[]
sp (x:xs) (y:ys)= (x*y):(sp xs ys)

makeMatrix::(a->b->c)->[a]->[b]->[[c]]
makeMatrix f [] []=[]
makeMatrix f xs []=[]
makeMatrix f [] ys=[]
makeMatrix f (x:xs) ys=[f x y|y<-ys]:makeMatrix f xs ys

vectorop::(Num a)=> (a->a->a)->[a]->[a]->[a]
vectorop f [] []=[]
vectorop f (x:xs) (y:ys)=(f x y):(vectorop f xs ys)

matrixop::(Num a)=> (a->a->a)->[[a]]->[[a]]->[[a]]
matrixop f [] []=[]
matrixop f (x:xs) (y:ys)=vectorop f x y:(matrixop f xs ys)

findMax::[Double]->(Int,Double)
findMax coll=(findIndex (findMaxVal coll) coll,(findMaxVal coll))

findMaxVal::[Double]->Double
findMaxVal [] = 0
findMaxVal coll=foldr max 0 coll

findIndex::Double->[Double]->Int
findIndex num []=0
findIndex num (x:xs)=if (x==num) then 0 else 1+(findIndex num xs)