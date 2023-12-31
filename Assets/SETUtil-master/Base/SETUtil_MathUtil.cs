﻿////////////////////////////////////////
//    Shared Editor Tool Utilities    //
//    by Kris Development             //
////////////////////////////////////////

//License: MIT
//GitLab: https://gitlab.com/KrisDevelopment/SETUtil

using U = UnityEngine;
using Mathf = UnityEngine.Mathf;
using SETUtil.Types;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SETUtil
{
	public static class MathUtil
	{
		/// <summary>
		/// Remaps the value from its expected low and high to the new low2 and high2
		/// </summary>
		public static float Map(float val, float low1, float high1, float low2, float high2)
		{
			return low2 + (val - low1) * ((high2 - low2) / (high1 - low1));
		}

		public static float Saturate(float val)
		{
			return U.Mathf.Clamp(val, 0f, 1f);
		}

		/// <summary>
		/// Samples volumetric perlin noise
		/// </summary>
		public static float PerlinVolume(U.Vector3 point, float perlinScale, int seed)
		{
			U.Vector3 _noisePoint = new U.Vector3(seed + point.x * perlinScale,
				(seed + 5) + point.y * perlinScale,
				(seed - 7) + point.z * perlinScale);
			
			float _ab = Mathf.PerlinNoise(_noisePoint.x, _noisePoint.y);
			float _bc = Mathf.PerlinNoise(_noisePoint.y, _noisePoint.z);
			float _ac = Mathf.PerlinNoise(_noisePoint.x, _noisePoint.z);
			
			float _ba = Mathf.PerlinNoise(_noisePoint.y, _noisePoint.x);
			float _cb = Mathf.PerlinNoise(_noisePoint.z, _noisePoint.y);
			float _ca = Mathf.PerlinNoise(_noisePoint.z, _noisePoint.x);

			return (_ab + _bc + _ac + _ba + _cb + _ca) / 6f;
		}

		
		/// <summary>
		/// Returns positive angle if the target is to the right on the transform data and negative if on the left 
		/// </summary>
		public static float GetSignedAngle (TransformData transformData, U.Vector3 target)
		{
			if((transformData.position - target).magnitude == 0){
				return 0;
			}

			float _sign = 1;
			U.Vector3 _projectedTarget = U.Vector3.ProjectOnPlane(target - transformData.position, transformData.up);

			if(U.Vector3.Angle(transformData.right, _projectedTarget) < 90){
				_sign = 1;
			}else{
				_sign = -1;
			}

			return U.Vector3.Angle(_projectedTarget, transformData.forward) * _sign;
		}

		///<summary> Returns the quaternion you need to multiply by to go into a given orientation relative to a rotation </summary>
		public static U.Quaternion FindRelativeRotation(U.Transform from, U.Transform to)
		{
			return from.rotation * U.Quaternion.Inverse(to.rotation);
		}

		/// <summary>
		/// Rotates the given Vector2 counterclockwise by the given angle
		/// </summary>
		public static U.Vector2 RotateVector2 (U.Vector2 vec, float angle)
		{
			angle = U.Mathf.Deg2Rad * angle;
			var _sinAngle = Mathf.Sin(angle);
			var _cosAngle = Mathf.Cos(angle);
			return new U.Vector2(_cosAngle * vec.x - _sinAngle * vec.y, _sinAngle * vec.x + _cosAngle * vec.y);
		}

		/// <summary>
		/// Evaluate a corner-cutting (subdivision) algorithm at a given distance along the curve.
		/// Iterations is the level of subdivision.
		/// </summary>
		public static U.Vector3 EvaluateChaikinCurve(float distance, U.Vector3[] controlPoints, uint iterations = 1)
        {
			if (distance <= 0)
			{
				return controlPoints[0];
			}

			// calculate the points at the given iteration count
			var _points = controlPoints;
            var _ptsl0m1 = _points.Length - 1;

            for (int i = 0; i < iterations; i++)
			{
				var _newPoints = new U.Vector3[_points.Length * 2];
				for (int p = 0; p < _ptsl0m1; p++)
				{
					var _p2 = p * 2;
					var _pNxt = p + 1;
					_newPoints[_p2 + 0] = U.Vector3.LerpUnclamped(_points[p], _points[_pNxt], .25f);
					_newPoints[_p2 + 1] = U.Vector3.LerpUnclamped(_points[p], _points[_pNxt], .75f);
				}
				_points = _newPoints;
			}

			var _ptsl = _points.Length;
			var _ptslm1 = _ptsl - 1;
			var _distances = new float[_ptslm1];

			// add starting and ending points
			{
				var _newPoints = new U.Vector3[_ptsl + 2];
				_newPoints[0] = controlPoints[0];
				_newPoints[_newPoints.Length - 1] = controlPoints[controlPoints.Length - 1];
				for (int i = 0; i < _ptslm1; i++)
                {
					_newPoints[i + 1] = _points[i];
					// record distances between points
					_distances[i] = U.Vector3.Distance(_points[i], _points[i + 1]);
				}

                //last point
                _newPoints[_ptslm1 + 1] = _points[_ptslm1];
            }

            // evaluate position
            float _currentDistance = 0;
			var _dl = _distances.Length;
			for (int i = 0; i < _dl; i ++)
            {
				var _startingDistance = _currentDistance;
				var _ptpDistance = _distances[i];
				_currentDistance += _ptpDistance;
                if (_currentDistance > distance)
                {
					return U.Vector3.LerpUnclamped(_points[i], _points[i + 1], (distance - _startingDistance) / _ptpDistance);
                }
            }

			return _points[_points.Length - 1];
		}

        /// <summary>
        /// Get power of two for positive integers (2 ^ n).
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PowOf2 (uint power)
        {
            if (power == 0)
            {
				return 1;
            }

			var _result = 2;
            for (int i = 1; i < power; i++)
            {
				_result *= 2;
            }

			return _result;
        }
	}
}