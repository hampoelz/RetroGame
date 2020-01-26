using System;
using System.CodeDom.Compiler;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.CSharp;

namespace RetroGame.Engine.DataTypes
{
    // ----------------- //
    // ----| To-Do |---- //
    // ----------------- //

    #region To-Do

    /*
     *   ⭕ Start
     *      Finish
     *      Checkpoint
     *      Coin
     *   ✔ Wall
     *   ⭕ FakeWall
     *      Speed
     *      Slowness
     *      Death
     *      Teleporter
     *      Fly
     *   ✔ Jump
     *      Custom
     *      RainbowBlock
     *      SizeChanger
     *   ✔ GravityChanger
     *      MapRotation
     *      UnstableWall
     *      Night
     *      InvertedMove
     */

    #endregion

    public class Block
    {
        private (string code, string codeNamespace, string codeClass) _code;

        public string Name { get; set; }
        public int Id { get; set; }

        public Border Control { get; protected set; } = new Border();

        public (Point Point, Size Size) Position { get; set; }

        // ------------- //
        // --| To-Do |-- //
        // ------------- //

        #region To-Do

        public (string Code, string Namespace, string Class) Code
        {
            get => _code;
            set
            {
                var provider = new CSharpCodeProvider();
                var results = provider.CompileAssemblyFromSource(new CompilerParameters(), value.Code);

                if (results.Errors.HasErrors)
                {
                    var sb = new StringBuilder();

                    foreach (CompilerError error in results.Errors)
                        sb.AppendLine($"Error ({error.ErrorNumber}): {error.ErrorText}");

                    throw new InvalidOperationException(sb.ToString());
                }

                CompiledCode = results.CompiledAssembly.GetType(value.Namespace + "." + value.Class);
                _code = value;
            }
        }

        #endregion

        public Type CompiledCode { get; set; }
    }
}