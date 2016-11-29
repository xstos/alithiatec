main=print(20)

foo::a->[a]->[a]
foo val lst=val:lst

makeMatrix::(a->b->c)->[a]->[b]->[[c]]
makeMatrix f [] []=[]
makeMatrix f xs []=[]
makeMatrix f [] ys=[]
makeMatrix f (x:xs) ys=[f x y|y<-ys]:makeMatrix f xs ys

myfunc x1 y1=(x1,y1)