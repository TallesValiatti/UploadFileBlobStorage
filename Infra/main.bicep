/* 

az deployment sub create --name UploadFileBlobStorage --location eastus2 --template-file main.bicep
az deployment sub what-if --name UploadFileBlobStorage --location eastus2 --template-file main.bicep
az group delete --name rg-upload-app-prod-eastus2

*/

// Scope
targetScope = 'subscription'

// Default Location
param defaultLocation string = deployment().location

// Shared Variables
var workflowName = 'upload-app'
var workflowEnvironment = 'prod'
var rgDefaultName = 'rg-${workflowName}-${workflowEnvironment}-<REGION>'

// Resource Group Variables
var rgName = replace(rgDefaultName, '<REGION>', defaultLocation)

// Storage Account Variables
var storageAccountName = 'uploadappstorage'
var storageAccountSku  = 'Standard_LRS'
var storageAccountKind = 'StorageV2'
var containerName = 'mycontainer'

resource rg 'Microsoft.Resources/resourceGroups@2020-10-01' = {
  location: defaultLocation
  name: rgName
}

module storageAccountModule 'Modules/storageAccountModule.bicep' = {
  name: 'storageAccountModule'
  scope: rg
  params: {
    containerName: containerName
    storageAccountName: storageAccountName
    kind: storageAccountKind
    sku: storageAccountSku
    location: defaultLocation
  }  
}
