﻿//-----------------------------------------------------------------------
// <copyright file="ISymmetricKeyAlgorithmProvider.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PCLCrypto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a provider of symmetric key algorithms.
    /// </summary>
    public interface ISymmetricKeyAlgorithmProvider
    {
        /// <summary>
        /// Gets the size, in bytes, of the cipher block for the open algorithm.
        /// </summary>
        /// <value>Block size.</value>
        int BlockLength { get; }

        /// <summary>
        /// Creates a symmetric key.
        /// </summary>
        /// <param name="keyMaterial">
        /// Data used to generate the key. You can call the GenerateRandom method to
        /// create random key material.
        /// </param>
        /// <returns>Symmetric key.</returns>
        ICryptographicKey CreateSymmetricKey(byte[] keyMaterial);
    }
}
