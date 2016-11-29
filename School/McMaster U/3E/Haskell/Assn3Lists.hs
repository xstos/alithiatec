main=print(20)

stutter :: [a] -> [a]
stutter []     = []
stutter (x:xs) = x : x : stutter xs

splits [] = []
splits [x] = []
splits (b:bs) = ([b],bs) : map (pupd1 (b:)) (splits bs)
          --  = ([b],bs) : [ (b:pre, suff) | (pre,suff) <- splits bs ]

pupd1 f (x,y) = (f x, y)

splits' [] = []
splits' (x : xs) = spl [x] xs
 where
  spl ys [] = []
  spl ys (xs@(x : xs')) = (ys, xs) : spl (ys ++ [x]) xs'

rotations :: [a] -> [[a]]
rotations xs = xs : map (uncurry (flip (++))) (splits xs)
         --  = xs : [ suff ++ pre  |  (pre, suff) <- splits xs ]

rotations' xs = r [] xs
 where
  r ys [] = [ys]
  r ys xs@(x : xs') = (xs ++ ys) : r (ys ++ [x]) xs'


permutations :: [a] -> [[a]]
permutations [] = [[]]
permutations xs =
  concat [ map (y:) (permutations ys)  |  (y : ys) <- rotations xs ]

permutations' [] = [[]]
permutations' xs = concatMap permAux (rotations xs)
  where
   permAux (y : ys) = map (y:) (permutations ys)
