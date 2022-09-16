using System;

namespace n.editor
{
    public partial class DialogData
    {

        #region Scene

        public enum ScenePresets
        {
            None = 0,
            Custom = 1,
            Scene1 = 2,
            Scene2 = 3,
        }
        
        private ScenePresets[] _scenePresets;

        public ScenePresets[] scenePresets
        {
            get
            {
                if (_scenePresets == null)
                {
                    _scenePresets = new ScenePresets[]
                    {
                        ScenePresets.None,
                        ScenePresets.Custom,
                        ScenePresets.Scene1,
                        ScenePresets.Scene2,
                    };
                }

                return _scenePresets;
            }
        }
        
        #endregion

        #region BGM

        public enum BGMPresets
        {
            None = 0,
            Custom = 1,
            Bgm1 = 2,
            Bgm2 = 3,
        }
        
        private BGMPresets[] _bgmPresets;

        public BGMPresets[] bgmPresets
        {
            get
            {
                if (_bgmPresets == null)
                {
                    _bgmPresets = new BGMPresets[]
                    {
                        BGMPresets.None,
                        BGMPresets.Custom,
                        BGMPresets.Bgm1,
                        BGMPresets.Bgm2,
                    };
                }

                return _bgmPresets;
            }
        }

        #endregion

        #region FX
       
        public enum FXPresets
        {
            None = 0,
            Custom = 1,
            FX1 = 2,
            FX2 = 3,
        }
        
        private FXPresets[] _fxPresets;

        public FXPresets[] fxPresets
        {
            get
            {
                if (_fxPresets == null)
                {
                    _fxPresets = new FXPresets[]
                    {
                        FXPresets.None,
                        FXPresets.Custom,
                        FXPresets.FX1,
                        FXPresets.FX2,
                    };
                }

                return _fxPresets;
            }
        }

        #endregion

        #region Shake

        public enum ShakePresets
        {
            None = 0,
            Shake1 = 2,
        }
        
        private ShakePresets[] _shakePresets;

        public ShakePresets[] shakePresets
        {
            get
            {
                if (_shakePresets == null)
                {
                    _shakePresets = new ShakePresets[]
                    {
                        ShakePresets.None,
                        ShakePresets.Shake1,
                    };
                }

                return _shakePresets;
            }
        }

        #endregion

        #region Lens

        public enum LensPresets
        {
            None = 0,
            Lens1 = 2,
        }
        
        private LensPresets[] _lensPresets;

        public LensPresets[] lensPresets
        {
            get
            {
                if (_lensPresets == null)
                {
                    _lensPresets = new LensPresets[]
                    {
                        LensPresets.None,
                        LensPresets.Lens1,
                    };
                }

                return _lensPresets;
            }
        }
        
        #endregion

        #region Transit

        public enum TransitPresets
        {
            None = 0,
            Transit1 = 2,
        }
        
        private TransitPresets[] _transitPresets;

        public TransitPresets[] transitPresets
        {
            get
            {
                if (_transitPresets == null)
                {
                    _transitPresets = new TransitPresets[]
                    {
                        TransitPresets.None,
                        TransitPresets.Transit1,
                    };
                }

                return _transitPresets;
            }
        }

        #endregion

        #region Dialog

        public enum DialogPreset
        {
            None = 0,
            Custom = 1,
            Dialog1 = 2,
        }

        private DialogPreset[] _dialogPresets;

        public DialogPreset[] dialogPresets
        {
            get
            {
                if (_dialogPresets == null)
                {
                    _dialogPresets = new DialogPreset[]
                    {
                        DialogPreset.None,
                        DialogPreset.Custom,
                        DialogPreset.Dialog1,
                    };
                }

                return _dialogPresets;
            }
        }
        #endregion

        #region Charactor

        public enum CharactorPresets
        {
            None = 0,
            Custom = 1,
            Char1 = 2,
        }
        
        private CharactorPresets[] _charPresets;

        public CharactorPresets[] charPresets
        {
            get
            {
                if (_charPresets == null)
                {
                    _charPresets = new CharactorPresets[]
                    {
                        CharactorPresets.None,
                        CharactorPresets.Custom,
                        CharactorPresets.Char1,
                    };
                }

                return _charPresets;
            }
        }

        #endregion

        #region charAnim

        public enum CharAnimPresets
        {
            None = 0,
            Custom = 1,
            Idel = 2,
        }
        
        private CharAnimPresets[] _charAnimPresets;

        public CharAnimPresets[] charAnimPresets
        {
            get
            {
                if (_charAnimPresets == null)
                {
                    _charAnimPresets = new CharAnimPresets[]
                    {
                        CharAnimPresets.None,
                        CharAnimPresets.Custom,
                        CharAnimPresets.Idel,
                    };
                }

                return _charAnimPresets;
            }
        }

        #endregion
    }

    public partial class ConditionData
    {
        public enum ConditonPresets
        {
            None = 0,
            Custom = 1,
            Conditon_1 = 2,
        }

        private ConditonPresets[] _conditonPresets;

        public ConditonPresets[] conditonPresets
        {
            get
            {
                if (_conditonPresets == null)
                {
                    _conditonPresets = new ConditonPresets[]
                    {
                        ConditonPresets.None,
                        ConditonPresets.Custom,
                        ConditonPresets.Conditon_1,
                    };
                }

                return _conditonPresets;
            }
        }
    }
    
}