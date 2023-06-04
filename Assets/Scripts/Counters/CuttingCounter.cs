using System;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

namespace Counters {
    public class CuttingCounter : BaseCounter, IHasProgress {
        public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler OnCut;

        [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

        private int _cuttingProgress;

        public override void Interact(Player player) {
            if (!HasKitchenObject()) {
                if (player.HasKitchenObject()) {
                    // Player is carrying something
                    if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                        // Player carrying something that can be Cut
                        player.GetKitchenObject().SetKitchenObjectParent(this);
                        _cuttingProgress = 0;

                        CuttingRecipeSO cuttingRecipeSO = 
                            GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                            ProgressNormalized = (float)_cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                        });
                    } else Debug.Log("CuttingCounter.Interact() Player carrying something that can't be cut");
                } else Debug.Log("CuttingCounter.Interact() Player not carrying anything");
            }
            else {
                // There is a KitchenObject here
                if (player.HasKitchenObject())
                    Debug.Log("CuttingCounter.Interact() Player is carrying something");
                else GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

        public override void InteractAlternate(Player player) {
            Debug.Log("CuttingCounter.InteractAlternate()");
            if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
                // There is a KitchenObject here AND it can be cut
                _cuttingProgress++;

                OnCut?.Invoke(this, EventArgs.Empty);

                CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                    ProgressNormalized = (float)_cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                });

                if (_cuttingProgress < cuttingRecipeSO.cuttingProgressMax) return;
                KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }

        private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
            return cuttingRecipeSO != null;
        }

        private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO) {
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
            if (cuttingRecipeSO != null) {
                return cuttingRecipeSO.output;
            }
            else {
                return null;
            }
        }

        private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO) {
            return cuttingRecipeSOArray.FirstOrDefault(cuttingRecipeSO => cuttingRecipeSO.input == inputKitchenObjectSO);
        }
    }
}