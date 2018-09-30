packageName="botv4-demo"
target="netcoreapp2.1"
dotnet publish --configuration Release
cd "./bin/Release/$target/publish/" # MUST have a better way to zip instead of changing directoy
zip -r "../../../../$packageName.zip" *
cd ../../../..
terraform apply -auto-approve