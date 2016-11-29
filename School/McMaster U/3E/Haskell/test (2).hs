main=print(20)

f1::Fractional a=>a->a
f1 a=a/2

f2::Fractional a=>a->a
f2 a=a^2

nul::[a]->Bool
nul []=True
nul _=False

listop f []=0
listop f (x:xs)=if null xs then x else f x (listop f xs)

lst::[a]->a
lst [x,y]=y
lst (_:xs)=last xs

stutter::[a]->[a]
stutter []=[]
stutter (x:xs)=x:[x]++stutter xs
