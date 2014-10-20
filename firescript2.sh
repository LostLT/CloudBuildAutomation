rm date.txt         
touch date.txt					
echo $(date) >> date.txt				
git add -A
git commit -a -m update 
git push origin master
